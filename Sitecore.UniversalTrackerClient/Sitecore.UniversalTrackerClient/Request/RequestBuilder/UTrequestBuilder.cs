using System;
using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
	public class UTRequestBuilder
    {
		private UTRequestBuilder()
        {
        }
        
		public static IEventrequestParametersBuilder<ITrackEventRequest> TrackEventRequestForItem(string itemId)
        {
            return new TrackEventForItemIdRequestBuilder(itemId);
        }
        
        

    }
}
