namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackSearchTask : AbstractTrackBaseEventTask<ITrackSearchRequest>
    {

        public TrackSearchTask(
            TrackEventUrlBuilder<ITrackSearchRequest> trackSearchUrlBuilder,
            HttpClient httpClient) : base(trackSearchUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackSearchRequest request)
        {
            Collection<IUTSearch> events = new Collection<IUTSearch>();
            events.Add(request.SearchEvent);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED SEARCH EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}