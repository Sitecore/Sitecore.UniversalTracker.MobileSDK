using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    internal class InteractionRequestBuilder : AbstractInteractionRequestBuilder<ITrackInteractionRequest>
    {
        public InteractionRequestBuilder()
        {
        }

        public override ITrackInteractionRequest Build()
        {
#warning @igk check thar all required fields is not null here!!!

            TrackInteractionParameters result =
                new TrackInteractionParameters(null, this.InteractioinParametersAccumulator);
            return result;
        }
    }
}