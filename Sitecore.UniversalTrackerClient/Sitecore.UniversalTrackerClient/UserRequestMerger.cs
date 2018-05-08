namespace Sitecore.UniversalTrackerClient
{
    using Sitecore.UniversalTrackerClient.Session;
    using Sitecore.UniversalTrackerClient.Session.Config;
    using Sitecore.UniversalTrackerClient.TrackEvent;
    using Sitecore.UniversalTrackerClient.UrlBuilder.TrackEvent;
	using Sitecore.UniversalTrackerClient.UserRequest;

	internal class UserRequestMerger
    {
		public SessionConfigMerger SessionConfigMerger { get; private set; }

        public UserRequestMerger(IUTSessionConfig sessionConfig)
        {
			this.SessionConfigMerger = new SessionConfigMerger(sessionConfig);
        }

        public ITrackEventRequest FillTrackEventGaps(ITrackEventRequest userRequest)
        {
			var trackParameters = new TrackParameters(userRequest.EventId, userRequest.FieldsRawValuesByName);

			IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            return new TrackEventParameters(mergedSessionConfig, trackParameters);
        }
    }
}