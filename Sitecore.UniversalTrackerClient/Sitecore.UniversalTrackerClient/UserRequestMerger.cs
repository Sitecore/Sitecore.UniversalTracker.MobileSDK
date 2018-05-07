using Sitecore.UniversalTrackerClient.Session;

namespace Sitecore.UniversalTrackerClient
{
    internal class UserRequestMerger
    {
        private IUTSessionConfig sessionConfig;

        public UserRequestMerger(IUTSessionConfig sessionConfig)
        {
            this.sessionConfig = sessionConfig;
        }

        public ITrackEventRequest FillTrackEventGaps(ITrackEventRequest userRequest)
        {
            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionSettings);

            return new TrackEventParameters();
        }
    }
}