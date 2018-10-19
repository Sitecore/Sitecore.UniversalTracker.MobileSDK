namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackCampaignTask : AbstractTrackBaseEventTask<ITrackCampaignRequest>
    {

        public TrackCampaignTask(
            TrackEventUrlBuilder<ITrackCampaignRequest> trackCampaignUrlBuilder,
            HttpClient httpClient) : base(trackCampaignUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackCampaignRequest request)
        {
            Collection<IUTCampaign> events = new Collection<IUTCampaign>();
            events.Add(request.Campaign);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED CAMAIGN EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}