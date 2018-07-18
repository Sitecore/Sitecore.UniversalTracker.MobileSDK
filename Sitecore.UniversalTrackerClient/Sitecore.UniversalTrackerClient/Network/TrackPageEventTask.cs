namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;

    internal class TrackPageEventTask : AbstractTrackBaseEventTask<ITrackPageViewRequest>
    {

        public TrackPageEventTask(
            TrackEventUrlBuilder<ITrackPageViewRequest> trackPageEventUrlBuilder,
            HttpClient httpClient) : base(trackPageEventUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackPageViewRequest request)
        {
            string serializedEvent = JsonConvert.SerializeObject(request.PageView,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            return serializedEvent;
        }

    }
}