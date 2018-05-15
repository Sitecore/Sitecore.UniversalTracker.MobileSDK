namespace Sitecore.UniversalTrackerClient
{
	using Sitecore.UniversalTrackerClient.Entities;
	using Sitecore.UniversalTrackerClient.Session.Config;
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
			var utEvent = new UTEvent(
				userRequest.Event.Timestamp,
				userRequest.Event.CustomValues,
				userRequest.Event.DefinitionId,
				userRequest.Event.ItemId,
				userRequest.Event.EngagementValue,
				userRequest.Event.ParentEventId,
				userRequest.Event.Text,
				userRequest.Event.Duration
			);

			IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

			return new TrackEventParameters(mergedSessionConfig, utEvent);
        }
    }
}