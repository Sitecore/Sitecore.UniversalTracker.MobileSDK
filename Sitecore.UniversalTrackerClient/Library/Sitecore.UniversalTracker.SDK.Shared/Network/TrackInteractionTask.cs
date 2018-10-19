namespace Sitecore.UniversalTrackerClient.TaskFlow
{
    using System.Net.Http;
    using Sitecore.UniversalTrackerClient.UserRequest;

    using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
    using Newtonsoft.Json;
    using System.Diagnostics;

    internal class TrackInteractionTask : AbstractTrackBaseEventTask<ITrackInteractionRequest>
    {

        public TrackInteractionTask(
            TrackInteractionUrlBuilder<ITrackInteractionRequest> trackInteractionUrlBuilder,
            HttpClient httpClient) : base(trackInteractionUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackInteractionRequest request)
        {
            string serializedInteraction = JsonConvert.SerializeObject(request.Interaction,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED INTERACTION EVENT:");
            Debug.WriteLine(serializedInteraction);

            return serializedInteraction;
        }

    }
}