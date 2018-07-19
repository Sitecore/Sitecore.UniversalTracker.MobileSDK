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

            //order matters!
			IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);
            utEvent.ApplyActiveInteractionWith(mergedSessionConfig.ActiveInteractionId);

			return new TrackEventParameters(mergedSessionConfig, utEvent);
        }

        public ITrackOutcomeRequest FillTrackOutcomeGaps(ITrackOutcomeRequest userRequest)
        {

            var utOutcome = userRequest.Outcome.DeepCopyUTOutcome();

            //order matters!
            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);
            utOutcome.ApplyActiveInteractionWith(mergedSessionConfig.ActiveInteractionId);

            return new TrackOutcomeParameters(mergedSessionConfig, utOutcome);
        }

        public ITrackPageViewRequest FillTrackPageViewGaps(ITrackPageViewRequest userRequest)
        {

            var utPageView = userRequest.PageView.DeepCopyUTPageView();

            //order matters!
            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);
            utPageView.ApplyActiveInteractionWith(mergedSessionConfig.ActiveInteractionId);

            return new TrackPageViewParameters(mergedSessionConfig, utPageView);
        }


        public ITrackInteractionRequest FillTrackInteractionGaps(ITrackInteractionRequest userRequest)
        {
            var utInteraction = userRequest.Interaction.DeepCopyUTInteraction();

            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            return new TrackInteractionParameters(mergedSessionConfig, utInteraction);
        }

    }
}