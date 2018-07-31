namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackEventTask : AbstractTrackBaseEventTask<ITrackEventRequest>
    {

        public TrackEventTask(
            TrackEventUrlBuilder<ITrackEventRequest> trackEventUrlBuilder,
            HttpClient httpClient) : base(trackEventUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackEventRequest request)
        {
            Collection<IUTEvent> events = new Collection<IUTEvent>();
            events.Add(request.Event);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED BASE EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}