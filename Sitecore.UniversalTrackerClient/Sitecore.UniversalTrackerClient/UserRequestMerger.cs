namespace Sitecore.UniversalTrackerClient
{
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
	using Sitecore.UniversalTrackerClient.Session.Config;
	using Sitecore.UniversalTrackerClient.UserRequest;

	internal class UserRequestMerger
    {
		public SessionConfigMerger SessionConfigMerger { get; private set; }
        private string defaultDeviceIdentifier;

        public UserRequestMerger(IUTSessionConfig sessionConfig, string deviceIdentifier)
        {
			this.SessionConfigMerger = new SessionConfigMerger(sessionConfig);
            this.defaultDeviceIdentifier = deviceIdentifier;
        }

        public ITrackEventRequest FillTrackEventGaps(ITrackEventRequest userRequest)
        {
            IUTEvent utEvent = userRequest.Event.DeepCopyUTEvent();

            //order matters!
			IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            utEvent = this.ApplyActiveInteraction(utEvent, mergedSessionConfig);
            utEvent = this.ApplyDeviceIdentifier(utEvent);

			return new TrackEventParameters(mergedSessionConfig, utEvent);
        }

        public ITrackOutcomeRequest FillTrackOutcomeGaps(ITrackOutcomeRequest userRequest)
        {

            var utOutcome = userRequest.Outcome.DeepCopyUTOutcome();

            //order matters!
            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            var utEvent = this.ApplyActiveInteraction(utOutcome, mergedSessionConfig);
            utEvent = this.ApplyDeviceIdentifier(utEvent);

            utOutcome = new UTOutcome(utEvent, utOutcome.CurrencyCode, utOutcome.MonetaryValue);

            return new TrackOutcomeParameters(mergedSessionConfig, utOutcome);
        }

        public ITrackPageViewRequest FillTrackPageViewGaps(ITrackPageViewRequest userRequest)
        {

            var utPageView = userRequest.PageView.DeepCopyUTPageView();

            //order matters!
            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            var utEvent = this.ApplyActiveInteraction(utPageView, mergedSessionConfig);
            utEvent = this.ApplyDeviceIdentifier(utEvent);

            utPageView = new UTPageView(utEvent, utPageView.ItemLanguage, utPageView.ItemVersion, utPageView.Url, utPageView.SitecoreRenderingDevice);

            return new TrackPageViewParameters(mergedSessionConfig, utPageView);
        }

        public ITrackSearchRequest FillTrackSearchGaps(ITrackSearchRequest userRequest)
        {

            var utSearch = userRequest.SearchEvent.DeepCopyUTSearch();

            //order matters!
            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            var utEvent = this.ApplyActiveInteraction(utSearch, mergedSessionConfig);
            utEvent = this.ApplyDeviceIdentifier(utEvent);

            utSearch = new UTSearch(utEvent, utSearch.Keywords);

            return new TrackSearchParameters(mergedSessionConfig, utSearch);
        }


        public ITrackInteractionRequest FillTrackInteractionGaps(ITrackInteractionRequest userRequest)
        {
            var utInteraction = userRequest.Interaction.DeepCopyUTInteraction();

            IUTSessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionConfig);

            return new TrackInteractionParameters(mergedSessionConfig, utInteraction);
        }

        private IUTEvent ApplyActiveInteraction(IUTEvent utEvent, IUTSessionConfig sessionConfig)
        {
            if (utEvent.TrackingInteractionId != null || sessionConfig.ActiveInteractionId == null)
            {
                return utEvent;
            }

            IUTEvent mergedEvent = new UTEvent(
                utEvent.Timestamp,
                utEvent.CustomValues,
                utEvent.DefinitionId,
                utEvent.ItemId,
                utEvent.EngagementValue,
                utEvent.ParentEventId,
                utEvent.Text,
                utEvent.Duration,
                utEvent.type,
                sessionConfig.ActiveInteractionId
            );

            return mergedEvent;
        }

        private IUTEvent ApplyDeviceIdentifier(IUTEvent utEvent)
        {
            string deviceInfoKey = UTGrammar.UTV1Grammar().DeviceIdentifierKeyValue;
            string deviceInfoValue = null;

            Dictionary<string, string> mergedCustomValues = utEvent.CustomValues;

            if (mergedCustomValues == null)
            {
                mergedCustomValues = new Dictionary<string, string>();
            }

            if (mergedCustomValues.ContainsKey(deviceInfoKey))
            {
                deviceInfoValue = mergedCustomValues[deviceInfoKey];
            }

            if (this.defaultDeviceIdentifier == null || deviceInfoValue != null)
            {
                return utEvent;
            }

            mergedCustomValues.Add(deviceInfoKey, this.defaultDeviceIdentifier);

            IUTEvent mergedEvent = new UTEvent(
                utEvent.Timestamp,
                mergedCustomValues,
                utEvent.DefinitionId,
                utEvent.ItemId,
                utEvent.EngagementValue,
                utEvent.ParentEventId,
                utEvent.Text,
                utEvent.Duration,
                utEvent.type,
                utEvent.TrackingInteractionId
            );

            return mergedEvent;
        }

    }
}