
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;

    internal class GoalBuilder : AbstractEventRequestBuilder<IUTGoal>
    {
        public GoalBuilder()
        {
        }

        public override IUTGoal Build()
        {

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

            IUTGoal result = new UTGoal(this.EventParametersAccumulator);

            return result;
        }
    }
}