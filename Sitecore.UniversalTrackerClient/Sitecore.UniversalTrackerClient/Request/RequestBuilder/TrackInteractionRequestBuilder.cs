using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    internal class TrackInteractionRequestBuilder : AbstractInteractionRequestBuilder<ITrackInteractionRequest>
    {


        public TrackInteractionRequestBuilder()
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