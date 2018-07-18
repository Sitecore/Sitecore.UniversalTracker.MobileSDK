
namespace Sitecore.UniversalTrackerClient.Entities
{
    using System;
    using System.Collections.Generic;

    public class UTGoal : UTEvent
    {
        public UTGoal (
            DateTime? timestamp,
            Dictionary<string, string> customValues,
            string definitionId,
            string itemId,
            int? engagementValue,
            string parentEventId,
            string text,
            TimeSpan? duration,
            string type = "goal"
        ) : base (
            timestamp, 
            customValues,
            definitionId, 
            itemId, 
            engagementValue, 
            parentEventId, 
            text, 
            duration, 
            type
        )
        {
            
        }

    }
}
