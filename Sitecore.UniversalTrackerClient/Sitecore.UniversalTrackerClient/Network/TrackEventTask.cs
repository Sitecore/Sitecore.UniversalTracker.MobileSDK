namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Text;
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;

    internal class TrackEventTask : AbstractTrackBaseEventTask<ITrackEventRequest>
    {

        public TrackEventTask(
            TrackEventUrlBuilder<ITrackEventRequest> trackEventUrlBuilder,
            HttpClient httpClient) : base(trackEventUrlBuilder, httpClient)
        {

        }

        public override StringContent BodyContentForRequest(ITrackEventRequest request)
        {
            string serializedEvent = JsonConvert.SerializeObject(request.Event);
            return new StringContent(serializedEvent, Encoding.UTF8, "application/json");
        }

    }
}