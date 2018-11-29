namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackDownloadTask : AbstractTrackBaseEventTask<ITrackDownloadRequest>
    {

        public TrackDownloadTask(
            TrackEventUrlBuilder<ITrackDownloadRequest> trackDownloadUrlBuilder,
            HttpClient httpClient) : base(trackDownloadUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackDownloadRequest request)
        {
            Collection<IUTDownload> events = new Collection<IUTDownload>();
            events.Add(request.Download);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED DOWNLOAD EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}