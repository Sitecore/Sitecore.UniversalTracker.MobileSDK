
namespace Sitecore.UniversalTrackerClient.Entities
{
    using System;
    using System.Collections.Generic;

    public class UTGoal : UTEvent, IUTGoal
    {
        private UTGoal()
        {

        }

        public UTGoal(IUTEvent uTEvent) : base(
            uTEvent.Timestamp,
            uTEvent.CustomValues,
            uTEvent.DefinitionId,
            uTEvent.ItemId,
            uTEvent.EngagementValue,
            uTEvent.ParentEventId,
            uTEvent.Text,
            uTEvent.Duration,
            uTEvent.TrackingInteractionId,
            "goal"
        )
        {

        }

        public IUTGoal DeepCopyUTGoal()
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


            var utGoal = new UTGoal(utEvent);

            return utGoal;
        }
    }
}
