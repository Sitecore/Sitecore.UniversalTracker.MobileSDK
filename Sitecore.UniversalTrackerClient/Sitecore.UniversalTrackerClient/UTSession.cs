
namespace Sitecore.UniversalTrackerClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.Session;
    using Sitecore.UniversalTrackerClient.TaskFlow;

    public class UTSession : ISitecoreUTSession
    {
        #region Private Variables

        private readonly UserRequestMerger requestMerger;
        private HttpClient httpClient;
        private CookieContainer cookies;
        private HttpClientHandler handler;

        protected readonly IUTSessionConfig sessionConfig;
        private readonly string uTTokenValue;
        private readonly IUTUrlParameters utGrammar = UTUrlParameters.UTV1UrlParameters();

        #endregion Private Variables
        
        public UTSession(
            IUTSessionConfig config,
            string uTTokenValue = null)
        {
            if (null == config)
            {
                throw new ArgumentNullException("ScUniversalTrackerSession.config cannot be null");
             }

            this.sessionConfig = config.SessionConfigShallowCopy();
            this.requestMerger = new UserRequestMerger(this.sessionConfig, defaultSource, this.entitySource);

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

        public async Task<UTTrackEventResponse> TrackEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken))
        {
            ITrackEventRequest requestCopy = request.DeepCopyTrackEventRequest();
         

            ITrackEventRequest autocompletedRequest = this.requestMerger.FillTrackEventGaps(requestCopy);

            var urlBuilder = new TrackEventUrlBuilder(this.sscGrammar);
            var taskFlow = new TrackEventTask<ITrackEventRequest>(urlBuilder, this.httpClient);

            return await RestApiCallFlow.LoadRequestFromNetworkFlow(autocompletedRequest, taskFlow, cancelToken);
        }

        #endregion TrackEvent

        #region Authentication

        public async Task<UTAuthResponse> AuthenticateAsync(CancellationToken cancelToken = default(CancellationToken))
        {
            #warning not implemented!!!
            return null;
        }

        #endregion Authentication

        
      }
}
