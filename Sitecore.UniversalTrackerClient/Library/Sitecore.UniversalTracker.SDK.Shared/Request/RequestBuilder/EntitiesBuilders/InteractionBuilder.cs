
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;

    internal class InteractionBuilder : AbstractInteractionRequestBuilder<IUTInteraction>
    {
        public InteractionBuilder()
        {
        }

        public override IUTInteraction Build()
        {
            this.CheckDefaultsAndThrow(false);

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.EventsAggregator,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId,
                this.ContactAggregator
            );

            return this.InteractioinParametersAccumulator;
        }
    }
}