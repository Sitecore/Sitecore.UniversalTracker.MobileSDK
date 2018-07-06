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

            var utEvent = userRequest.Event.DeepCopyUTEvent();

			IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

			return new TrackEventParameters(mergedSessionConfig, utEvent);
        }

        public ITrackOutcomeRequest FillTrackOutcomeGaps(ITrackOutcomeRequest userRequest)
        {

            var utOutcome = userRequest.Outcome.DeepCopyUTOutcome();

            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            return new TrackOutcomeParameters(mergedSessionConfig, utOutcome);
        }


        public ITrackInteractionRequest FillTrackInteractionGaps(ITrackInteractionRequest userRequest)
        {
            var utInteraction = userRequest.Interaction.DeepCopyUTInteraction();

            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            return new TrackInteractionParameters(mergedSessionConfig, utInteraction);
        }

    }
}