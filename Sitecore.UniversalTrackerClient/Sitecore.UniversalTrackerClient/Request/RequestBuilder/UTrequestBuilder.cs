using System;
using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
	public class UTRequestBuilder
    {
		private UTRequestBuilder()
        {
        }
        
		public static IEventrequestParametersBuilder<ITrackEventRequest> EventForItem(string itemId)
        {
            return new EventForItemIdRequestBuilder<ITrackEventRequest>(itemId);
        }

        public static IEventrequestParametersBuilder<ITrackLocationEventRequest> LocationEvent(double latitude, double longitude)
        {
            return new LocationEventRequestBuilder(latitude, longitude);
        }

        public static IEventrequestParametersBuilder<ITrackErrorEventRequest> ErrorEvent(string error, string errorDescription)
        {
            return new ErrorEventRequestBuilder(error, errorDescription);
        }

        public static IEventrequestParametersBuilder<ITrackEventRequest> AppLaunchedEvent()
        {
            return new AppLaunchEventRequestBuilder();
        }

        public static IEventrequestParametersBuilder<ITrackEventRequest> AppFinishedEvent()
        {
            return new AppFinishedEventRequestBuilder();
        }

        public static IInteractionParametersBuilder<ITrackInteractionRequest> Interaction()
        {
            return new InteractionRequestBuilder();
        }

    }
}
