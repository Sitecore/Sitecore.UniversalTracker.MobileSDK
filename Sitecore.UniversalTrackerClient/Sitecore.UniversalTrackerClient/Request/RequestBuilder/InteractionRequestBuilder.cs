

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;

    internal class InteractionRequestBuilder : AbstractInteractionRequestBuilder<ITrackInteractionRequest>
    {
        public InteractionRequestBuilder(Collection<IUTEvent> utEvents)
        {
            this.AddEvents(utEvents);
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