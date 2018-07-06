namespace Sitecore.UniversalTrackerClient.TaskFlow
{
    using System.Text;
    using System.Net.Http;
    using Sitecore.UniversalTrackerClient.UserRequest;

    using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
    using Newtonsoft.Json;

    internal class TrackInteractionTask : AbstractTrackBaseEventTask<ITrackInteractionRequest>
    {

        public TrackInteractionTask(
            TrackEventUrlBuilder<ITrackInteractionRequest> trackInteractionUrlBuilder,
            HttpClient httpClient) : base(trackInteractionUrlBuilder, httpClient)
        {

        }

        public override StringContent BodyContentForRequest(ITrackInteractionRequest request)
        {
            string serializedInteraction = JsonConvert.SerializeObject(request.Interaction,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            return new StringContent(serializedInteraction, Encoding.UTF8, "application/json");
        }

    }
}