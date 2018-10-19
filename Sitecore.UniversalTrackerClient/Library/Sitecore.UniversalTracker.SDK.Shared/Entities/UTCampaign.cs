
namespace Sitecore.UniversalTrackerClient.Entities
{
    using System;
    using System.Collections.Generic;

    public class UTCampaign : UTEvent, IUTCampaign
    {

        private UTCampaign()
        {
        }

        public UTCampaign(IUTEvent utEvent, string campaignDefinitionId)
            : base(
                utEvent.Timestamp,
                utEvent.CustomValues,
                utEvent.DefinitionId,
                utEvent.ItemId,
                utEvent.EngagementValue,
                utEvent.ParentEventId,
                utEvent.Text,
                utEvent.Duration,
                utEvent.TrackingInteractionId,
                "campaign"
            )
        {
            this.CampaignDefinitionId = campaignDefinitionId;
        }

        public string CampaignDefinitionId
        {
            get;
            private set;
        }

        public IUTCampaign DeepCopyUTCampaign()
        {
            var utEvent = new UTEvent(
                this.Timestamp,
                this.CustomValues,
                this.DefinitionId,
                this.ItemId,
                this.EngagementValue,
                this.ParentEventId,
                this.Text,
                this.Duration,
                this.TrackingInteractionId
            );


            var utcamapign = new UTCampaign(
                utEvent,
                this.CampaignDefinitionId
            );

            return utcamapign;
        }


    }
}
