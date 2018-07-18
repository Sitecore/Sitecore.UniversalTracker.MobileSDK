
namespace Sitecore.UniversalTrackerClient
{
    using System;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Sitecore.UniversalTrackerClient.Response;
    using Sitecore.UniversalTrackerClient.Session;
    using Sitecore.UniversalTrackerClient.Session.Config;
    using Sitecore.UniversalTrackerClient.TaskFlow;
	using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;

    public class UTSession : ISitecoreUTSession
    {
        #region Private Variables

        private readonly UserRequestMerger requestMerger;
        private HttpClient httpClient;
        private CookieContainer cookies;
        private HttpClientHandler handler;

        protected IUTSessionConfig sessionConfig;
        protected readonly IUTInteraction defaultInteraction;

        private readonly string uTTokenValue;
        private readonly IUTGrammar utGrammar;

        private string activeInteractionId = null;

        #endregion Private Variables

        public UTSession
        (
            IUTSessionConfig config,
            string uTTokenValue = null,
            IUTInteraction interaction= null,
            IUTGrammar grammar = null
        )
        {
            if (null == config)
            {
				throw new ArgumentNullException(nameof(UTSession), " config cannot be null");
            }

            if (grammar == null)
            {
                grammar = UTGrammar.UTV1Grammar();
            }

            this.utGrammar = grammar;

            this.defaultInteraction = interaction;

            this.sessionConfig = config.SessionConfigShallowCopy();
            this.requestMerger = new UserRequestMerger(this.sessionConfig);

            this.uTTokenValue = uTTokenValue;

            this.cookies = new CookieContainer();
            this.handler = new HttpClientHandler();
            this.handler.CookieContainer = cookies;
            this.httpClient = new HttpClient(this.handler);
        }

        #region IDisposable
        void ReleaseResources()
        {
            Exception httpClientException = null;

            if (null != this.httpClient)
            {
                try
                {
                    this.httpClient.Dispose();
                }
                catch (Exception ex)
                {
                    httpClientException = ex;
                }
                this.httpClient = null;
            }

        }

        public virtual void Dispose()
        {
            this.ReleaseResources();
        }

        ~UTSession()
        {

        }
        #endregion IDisposable

        #region ISitecoreUTSessionState

        public IUTSessionConfig Config
        {
            get
            {
                return this.sessionConfig;
            }
        }

        public string UTTokenValue
        {
            get
            {
                return this.uTTokenValue;
            }
        }

        #endregion ISitecoreUTSessionState

        #region Forbidden Methods

        private UTSession()
        {
        }

        #endregion Forbidden Methods

        #region TrackEvent

        public async Task<UTResponse> TrackEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".request");

            ITrackEventRequest requestCopy = request.DeepCopyTrackEventRequest();

            if ( this.InteractionNotExists() )
            {
                return await this.CreateInteractionAndSentEventAsync(request, cancelToken);
            }

            ITrackEventRequest autocompletedRequest = this.requestMerger.FillTrackEventGaps(requestCopy);

			var urlBuilder = new TrackEventUrlBuilder<ITrackEventRequest>(this.utGrammar);
            var taskFlow = new TrackEventTask(urlBuilder, this.httpClient);

            return await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);
        }

        public async Task<UTResponse> TrackLocationEventAsync(ITrackLocationEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            return await this.TrackEventAsync(request, cancelToken);
        }

        public async  Task<UTResponse> TrackErrorEventAsync(ITrackErrorEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            return await this.TrackEventAsync(request, cancelToken);
        }

        public async Task<UTResponse> TrackOutcomeEventAsync(ITrackOutcomeRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".request");

            ITrackOutcomeRequest requestCopy = request.DeepCopyTrackOutcomeRequest();

            //@igk order matters!!!
            //this.AutoInteractionAsync(request, cancelToken); //FIXME: !!!!

            ITrackOutcomeRequest autocompletedRequest = this.requestMerger.FillTrackOutcomeGaps(requestCopy);

            var urlBuilder = new TrackEventUrlBuilder<ITrackOutcomeRequest>(this.utGrammar);
            var taskFlow = new TrackOutcomeTask(urlBuilder, this.httpClient);

            return await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);
        }

        #endregion TrackEvent


        #region Interaction

        public async Task<UTResponse> CreateInteractionAndSentEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            UTResponse interactionResponse = null;


            Collection<IUTEvent> events = new Collection<IUTEvent>();


            //FIXME: @igk temperary fix, to support instance bug, remove this code after fix
            //start code to remove

            var utEvent = new UTEvent
                (
                    request.Event.Timestamp,
                    request.Event.CustomValues,
                    request.Event.DefinitionId,
                    request.Event.ItemId,
                    request.Event.EngagementValue,
                    request.Event.ParentEventId,
                    request.Event.Text,
                    request.Event.Duration,
                    null
                );

            //end code to remove

            events.Add(utEvent);

            var interaction = new UTInteraction
                (
                this.defaultInteraction.CampaignId,
                this.defaultInteraction.ChannelId,
                this.defaultInteraction.EngagementValue,
                this.defaultInteraction.StartDateTime,
                this.defaultInteraction.EndDateTime,
                events,
                this.defaultInteraction.Initiator,
                this.defaultInteraction.UserAgent,
                this.defaultInteraction.VenueId,
                this.defaultInteraction.Contact
            );

            var interactionRequest = new TrackInteractionParameters(null, interaction);

            interactionResponse = await this.TrackInteractionAsync(interactionRequest, cancelToken);

            return interactionResponse;
        }

        public async Task<UTResponse> TrackInteractionAsync(ITrackInteractionRequest request, CancellationToken cancelToken)
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".request");

            ITrackInteractionRequest requestCopy = request.DeepCopyTrackInteractionRequest();

            ITrackInteractionRequest autocompletedRequest = this.requestMerger.FillTrackInteractionGaps(requestCopy);

            var urlBuilder = new TrackInteractionUrlBuilder<ITrackInteractionRequest>(this.utGrammar);
            var taskFlow = new TrackInteractionTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);
            if (response.Successful)
            {
                this.sessionConfig = new UTSessionConfig(this.sessionConfig.InstanceUrl, response.Description);
            }

            return response;
        }

        private bool InteractionNotExists()
        {
            bool interactionExpired = this.IsActiveInteractionExpired();
            bool interactionNotCreated = this.sessionConfig.ActiveInteractionId == null;

            return interactionExpired || interactionNotCreated;
        }

        private bool IsActiveInteractionExpired()
        {
#warning @igk not implemented!!
            return false;
        }

        #endregion Interaction
    }
}
