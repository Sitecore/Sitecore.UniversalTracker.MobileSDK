namespace Sitecore.UniversalTrackerClient.TaskFlow
{
    using System.Net.Http;
    using Sitecore.UniversalTrackerClient.UserRequest;

    using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
    using Newtonsoft.Json;
    using System.Diagnostics;

    internal class CompleteInteractionTask : AbstractTrackBaseEventTask<ICompleteInteractionRequest>
    {

        public CompleteInteractionTask(
            CompleteInteractionUrlBuilder<ICompleteInteractionRequest> completeInteractionUrlBuilder,
            HttpClient httpClient) : base(completeInteractionUrlBuilder, httpClient)
        {

        }

        public override HttpMethod HTTPMethod()
        {
            return HttpMethod.Post;
        }

        public override string RequestContentInJSON(ICompleteInteractionRequest request)
        {
            string serializedCompleteInteraction = "\"" + request.InteractionId + "\"";

            Debug.WriteLine("SERIALIZED COMPLETE INTERACTION EVENT:");
            Debug.WriteLine(serializedCompleteInteraction);

            return serializedCompleteInteraction;
        }

    }
}