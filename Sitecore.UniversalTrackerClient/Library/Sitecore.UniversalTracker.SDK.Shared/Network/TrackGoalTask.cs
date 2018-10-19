namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System.Net.Http;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using System.Diagnostics;

    internal class TrackGoalTask : AbstractTrackBaseEventTask<ITrackGoalRequest>
    {

        public TrackGoalTask(
            TrackEventUrlBuilder<ITrackGoalRequest> trackGoalUrlBuilder,
            HttpClient httpClient) : base(trackGoalUrlBuilder, httpClient)
        {

        }

        public override string RequestContentInJSON(ITrackGoalRequest request)
        {
            Collection<IUTGoal> events = new Collection<IUTGoal>();
            events.Add(request.Goal);

            string serializedEvent = JsonConvert.SerializeObject(events,
                           Newtonsoft.Json.Formatting.None,
                           new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });

            Debug.WriteLine("SERIALIZED GOAL EVENT:");
            Debug.WriteLine(serializedEvent);

            return serializedEvent;
        }

    }
}