namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackOutcomeTask : AbstractTrackBaseEventTask<ITrackOutcomeRequest>
    {

        public TrackOutcomeTask(
            TrackEventUrlBuilder<ITrackOutcomeRequest> trackOutcomeUrlBuilder,
            HttpClient httpClient) : base(trackOutcomeUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackOutcomeRequest request)
        {
            Collection<IUTOutcome> events = new Collection<IUTOutcome>();
            events.Add(request.Outcome);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED OUTCOME EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}