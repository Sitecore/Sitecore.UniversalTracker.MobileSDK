namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Text;
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;

    internal class TrackOutcomeTask : AbstractTrackBaseEventTask<ITrackOutcomeRequest>
    {

        public TrackOutcomeTask(
            TrackEventUrlBuilder<ITrackOutcomeRequest> trackEventUrlBuilder,
            HttpClient httpClient) : base(trackEventUrlBuilder, httpClient)
        {

        }

        public override StringContent BodyContentForRequest(ITrackOutcomeRequest request)
        {
            string serializedEvent = JsonConvert.SerializeObject(request.Outcome);
            return new StringContent(serializedEvent, Encoding.UTF8, "application/json");
        }

    }
}