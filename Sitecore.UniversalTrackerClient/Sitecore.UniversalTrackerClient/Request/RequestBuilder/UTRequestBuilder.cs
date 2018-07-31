
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;


	public class UTRequestBuilder
    {
		private UTRequestBuilder()
        {
        }

		public static IEventRequestParametersBuilder<ITrackEventRequest> EventWithDefenitionId(string defenitionId)
        {
            return new EventForDefenitionIdRequestBuilder<ITrackEventRequest>(defenitionId);
        }

        public static IEventRequestParametersBuilder<ITrackEventRequest> GoalWithDefenitionId(string defenitionId)
        {
            return new EventForDefenitionIdRequestBuilder<ITrackEventRequest>(defenitionId);
        }

        public static IOutcomeRequestParametersBuilder OutcomeWithDefenitionId(string defenitionId)
        {
            return new OutcomeRequestParametersBuilder(defenitionId);
        }

        public static IPageViewRequestParametersBuilder PageViewWithDefenitionId(string defenitionId)
        {
            return new PageViewRequestParametersBuilder(defenitionId);
        }

        public static ISearchRequestParametersBuilder SearchEvent(string defenitionId)
        {
            return new SearchRequestParametersBuilder(defenitionId);
        }

        public static IEventRequestParametersBuilder<ITrackLocationEventRequest> LocationEvent(double latitude, double longitude)
        {
            return new LocationEventRequestBuilder(latitude, longitude);
        }

        public static IEventRequestParametersBuilder<ITrackPageOpenedEventRequest> PageOpenedEvent(string padeId, DateTime timeStamp)
        {
            return new PageOpenedEventRequestBuilder(padeId, timeStamp);
        }

        public static IEventRequestParametersBuilder<ITrackPageClosedEventRequest> PageClosedEvent(string padeId, DateTime timeStamp)
        {
            return new PageClosedEventRequestBuilder(padeId, timeStamp);
        }

        public static DeviceInformationEventRequestBuilder DeviceInformationEvent(string deviceName)
        {
            return new DeviceInformationEventRequestBuilder(deviceName);
        }

        public static IEventRequestParametersBuilder<ITrackErrorEventRequest> ErrorEvent(string error, string errorDescription)
        {
            return new ErrorEventRequestBuilder(error, errorDescription);
        }

        public static IEventRequestParametersBuilder<ITrackEventRequest> AppLaunchedEvent()
        {
            return new AppLaunchEventRequestBuilder();
        }

        public static IEventRequestParametersBuilder<ITrackEventRequest> AppFinishedEvent()
        {
            return new AppFinishedEventRequestBuilder();
        }

        public static IInteractionParametersBuilder<ITrackInteractionRequest> Interaction(IUTEvent utEvent)
        {
            var list = new Collection<IUTEvent>();
            list.Add(utEvent);

            return UTRequestBuilder.Interaction(list);
        }

        public static IInteractionParametersBuilder<ITrackInteractionRequest> Interaction(Collection<IUTEvent> utEvents)
        {
            return new InteractionRequestBuilder(utEvents);
        }

    }
}
