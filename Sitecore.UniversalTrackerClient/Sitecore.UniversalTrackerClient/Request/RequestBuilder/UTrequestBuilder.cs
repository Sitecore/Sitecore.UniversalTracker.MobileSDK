using System;
using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
	public class UTRequestBuilder
    {
		private UTRequestBuilder()
        {
        }
        
		public static IEventrequestParametersBuilder<ITrackEventRequest> TrackEventForItem(string itemId)
        {
            return new TrackEventForItemIdRequestBuilder(itemId);
        }

        public static IInteractionParametersBuilder<ITrackInteractionRequest> TrackInteraction()
        {
            return new TrackInteractionRequestBuilder();
        }

    }
}
