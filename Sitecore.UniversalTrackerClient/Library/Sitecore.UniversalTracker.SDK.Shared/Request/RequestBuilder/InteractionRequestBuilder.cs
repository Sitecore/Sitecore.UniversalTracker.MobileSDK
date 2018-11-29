

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;

    internal class InteractionRequestBuilder : AbstractInteractionRequestBuilder<ITrackInteractionRequest>
    {
        public InteractionRequestBuilder(Collection<IUTEvent> utEvents)
        {
            this.AddEvents(utEvents);
        }

        public override ITrackInteractionRequest Build()
        {
            this.CheckDefaultsAndThrow();

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.EventsAggregator,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId,
                this.ContactAggregator
            );

            TrackInteractionParameters result =
                new TrackInteractionParameters(null, this.InteractioinParametersAccumulator);
            return result;
        }
    }
}