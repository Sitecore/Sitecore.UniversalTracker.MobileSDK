
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

        private UserRequestMerger requestMerger;
        private HttpClient httpClient;
        private CookieContainer cookies;
        private HttpClientHandler handler;
        private string defaultDeviceIdentifier;

        protected IUTSessionConfig sessionConfig;

        private readonly string uTTokenValue;
        private readonly IUTGrammar utGrammar;

        private IUTInteraction defaultInteraction;

        #endregion Private Variables

        public UTSession
        (
            IUTSessionConfig config,
            IUTInteraction defaultInteraction,
            string deviceIdentifier,
            string uTTokenValue,
            IUTGrammar grammar = null
        )
        {
            if (null == config)
            {
				throw new ArgumentNullException(nameof(UTSession), " config can not be null");
            }

            if (grammar == null)
            {
                grammar = UTGrammar.UTV1Grammar();
            }

            this.utGrammar = grammar;

            this.defaultInteraction = defaultInteraction;
            this.defaultDeviceIdentifier = deviceIdentifier;

            this.sessionConfig = config.SessionConfigShallowCopy();
            this.requestMerger = new UserRequestMerger(this.sessionConfig, this.defaultDeviceIdentifier);

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
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".EventRequest ");

            ITrackEventRequest requestCopy = request.DeepCopyTrackEventRequest();

            ITrackEventRequest autocompletedRequest = this.requestMerger.FillTrackEventGaps(requestCopy);

            if ( this.InteractionNotExists() )
            {
                return await this.CreateInteractionAndSentEventAsync(request.Event, cancelToken);
            }

			var urlBuilder = new TrackEventUrlBuilder<ITrackEventRequest>(this.utGrammar);
            var taskFlow = new TrackEventTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        public async Task<UTResponse> TrackLocationEventAsync(ITrackLocationEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            return await this.TrackEventAsync(request, cancelToken);
        }

        public async Task<UTResponse> TrackGoalAsync(ITrackGoalRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".GoalRequest");

            ITrackGoalRequest requestCopy = request.DeepCopyTrackGoalRequest();

            ITrackGoalRequest autocompletedRequest = this.requestMerger.FillTrackGoalGaps(requestCopy);


            //FIXME: @igk
            if (this.InteractionNotExists())
            {
                return await this.CreateInteractionAndSentEventAsync(request.Goal, cancelToken);
            }

            var urlBuilder = new TrackEventUrlBuilder<ITrackGoalRequest>(this.utGrammar);
            var taskFlow = new TrackGoalTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        public async  Task<UTResponse> TrackErrorEventAsync(ITrackErrorEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            return await this.TrackEventAsync(request, cancelToken);
        }

        public async Task<UTResponse> TrackOutcomeEventAsync(ITrackOutcomeRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".OutcomeRequest");

            ITrackOutcomeRequest requestCopy = request.DeepCopyTrackOutcomeRequest();

            ITrackOutcomeRequest autocompletedRequest = this.requestMerger.FillTrackOutcomeGaps(requestCopy);


            //FIXME: @igk
            if (this.InteractionNotExists())
            {
                return await this.CreateInteractionAndSentEventAsync(request.Outcome, cancelToken);
            }

            var urlBuilder = new TrackEventUrlBuilder<ITrackOutcomeRequest>(this.utGrammar);
            var taskFlow = new TrackOutcomeTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        public async Task<UTResponse> TrackPageViewEventAsync(ITrackPageViewRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".PageViewRequest");

            ITrackPageViewRequest requestCopy = request.DeepCopyTrackPageViewRequest();

            ITrackPageViewRequest autocompletedRequest = this.requestMerger.FillTrackPageViewGaps(requestCopy);

            //FIXME: @igk
            if (this.InteractionNotExists())
            {
                return await this.CreateInteractionAndSentEventAsync(request.PageView, cancelToken);
            }

            var urlBuilder = new TrackEventUrlBuilder<ITrackPageViewRequest>(this.utGrammar);
            var taskFlow = new TrackPageViewTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        public async Task<UTResponse> TrackSearchEventAsync(ITrackSearchRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".SearchEventRequest");

            ITrackSearchRequest requestCopy = request.DeepCopySearchRequest();

            ITrackSearchRequest autocompletedRequest = this.requestMerger.FillTrackSearchGaps(requestCopy);

            //FIXME: @igk
            if (this.InteractionNotExists())
            {
                return await this.CreateInteractionAndSentEventAsync(request.SearchEvent, cancelToken);
            }

            var urlBuilder = new TrackEventUrlBuilder<ITrackSearchRequest>(this.utGrammar);
            var taskFlow = new TrackSearchTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        public async Task<UTResponse> TrackCampaignEventAsync(ITrackCampaignRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".CampaignRequest");

            ITrackCampaignRequest requestCopy = request.DeepCopyTrackCampaignRequest();

            ITrackCampaignRequest autocompletedRequest = this.requestMerger.FillTrackCampaignGaps(requestCopy);

            //FIXME: @igk
            if (this.InteractionNotExists())
            {
                return await this.CreateInteractionAndSentEventAsync(request.Campaign, cancelToken);
            }

            var urlBuilder = new TrackEventUrlBuilder<ITrackCampaignRequest>(this.utGrammar);
            var taskFlow = new TrackCampaignTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        public async Task<UTResponse> TrackDownloadEventAsync(ITrackDownloadRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            BaseValidator.CheckNullAndThrow(request, this.GetType().Name + ".DownloadRequest");

            ITrackDownloadRequest requestCopy = request.DeepCopyTrackDownloadRequest();

            ITrackDownloadRequest autocompletedRequest = this.requestMerger.FillTrackDownloadGaps(requestCopy);

            //FIXME: @igk
            if (this.InteractionNotExists())
            {
                return await this.CreateInteractionAndSentEventAsync(request.Download, cancelToken);
            }

            var urlBuilder = new TrackEventUrlBuilder<ITrackDownloadRequest>(this.utGrammar);
            var taskFlow = new TrackDownloadTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);

            this.CheckResponseForValidInteraction(response);

            return response;
        }

        #endregion TrackEvent


        #region Interaction

        public async Task<UTResponse> CreateInteractionAndSentEventAsync(IUTEvent utEvent, CancellationToken cancelToken = default(CancellationToken))
        {
            UTResponse interactionResponse = null;


            Collection<IUTEvent> events = new Collection<IUTEvent>();


            //FIXME: @igk temporary fix, to support instance bug, remove this code after fix
            //start code to remove

            utEvent.type = null;

            //end code to remove

            events.Add(utEvent);

            var interaction = new UTInteraction
                (
                this.defaultInteraction.CampaignId,
                this.defaultInteraction.ChannelId,
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
                //@igk order matters
                this.sessionConfig = new UTSessionConfig(this.sessionConfig.InstanceUrl, response.Description);
                this.requestMerger = new UserRequestMerger(this.sessionConfig, this.defaultDeviceIdentifier);
            }

            return response;
        }

        public async Task<UTResponse> CompleteCurrentInteractionAsync(CancellationToken cancelToken = default(CancellationToken))
        {
            if (this.InteractionNotExists())
            {
                return new UTResponse(400, "No active interaction found", null);
            }

            ICompleteInteractionRequest request = new CompleteInteractionParameters(this.sessionConfig);

            var urlBuilder = new CompleteInteractionUrlBuilder<ICompleteInteractionRequest>(this.utGrammar);
            var taskFlow = new CompleteInteractionTask(urlBuilder, this.httpClient);

            var response = await RestApiCallFlow.LoadRequestFromNetworkFlow(request, taskFlow, cancelToken);
            if (response.Successful)
            {
                this.sessionConfig = new UTSessionConfig(this.sessionConfig.InstanceUrl);
            }

            return response;
        }

        private void CheckResponseForValidInteraction(UTResponse response)
        {
            //FIXME: @igk a special error code required!!!
            if (response.Description != null && response.Description.Contains("not a valid tracking interaction ID"))
            {
                this.sessionConfig = new UTSessionConfig(this.sessionConfig.InstanceUrl);
            }
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
