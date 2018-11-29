
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class GoalRequestParametersBuilder: AbstractEventRequestBuilder<ITrackGoalRequest>
    {
        
        private GoalRequestParametersBuilder()
        {

        }

        public GoalRequestParametersBuilder(string defenitionId, DateTime timestamp)
        {
            ItemIdValidator.ValidateItemId(defenitionId, this.GetType().Name + ".defenitionId");
            this.DefinitionId(defenitionId);
            this.Timestamp(timestamp);
        }

        public override ITrackGoalRequest Build()
        {
            this.CheckWholeObjectForCorrectnessOrThrow();

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

            UTGoal utGoal = new UTGoal(this.EventParametersAccumulator);

            TrackGoalParameters result = new TrackGoalParameters(null, utGoal);
            
            return result;
        }
    }
}

