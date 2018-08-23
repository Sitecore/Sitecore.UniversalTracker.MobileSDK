
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class CampaignRequestParametersBuilder : AbstractEventRequestBuilder<ITrackCampaignRequest>
    {
        private string CampaignDefinitionId;

        private  CampaignRequestParametersBuilder()
        {
            
        }

        public CampaignRequestParametersBuilder(string campaignDefinitionId)
        {
            ItemIdValidator.ValidateItemId(campaignDefinitionId, this.GetType().Name + ".defenitionId");
            this.CampaignDefinitionId = campaignDefinitionId;
        }

        public override ITrackCampaignRequest Build()
        {
#warning @igk check that all required fields is not null here!!!

            Dictionary<string, string> customParameters = null;

            if (this.FieldsRawValuesByName != null)
            {
                customParameters = new Dictionary<string, string>(this.FieldsRawValuesByName);
            }

            this.EventParametersAccumulator = new UTEvent(
                    this.EventParametersAccumulator.Timestamp,
                    customParameters,
                    this.EventParametersAccumulator.DefinitionId,
                    this.EventParametersAccumulator.ItemId,
                    this.EventParametersAccumulator.EngagementValue,
                    this.EventParametersAccumulator.ParentEventId,
                    this.EventParametersAccumulator.Text,
                    this.EventParametersAccumulator.Duration,
                    this.EventParametersAccumulator.TrackingInteractionId
                );

            UTCampaign camapign = new UTCampaign(this.EventParametersAccumulator, this.CampaignDefinitionId);

            TrackCampaignParameters result = new TrackCampaignParameters(null, camapign);

            return result;
        }

    }
}

