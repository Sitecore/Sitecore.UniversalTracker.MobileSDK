namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackPageViewTask : AbstractTrackBaseEventTask<ITrackPageViewRequest>
    {

        public TrackPageViewTask(
            TrackEventUrlBuilder<ITrackPageViewRequest> trackPageEventUrlBuilder,
            HttpClient httpClient) : base(trackPageEventUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackPageViewRequest request)
        {
            Collection<IUTPageView> events = new Collection<IUTPageView>();
            events.Add(request.PageView);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED PAGE VIEW EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}