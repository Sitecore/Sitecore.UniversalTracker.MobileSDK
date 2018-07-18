

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;

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
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
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