using System;
using System.Collections.Generic;

namespace Sitecore.UniversalTrackerClient.Entities
{
	public class UTEvent : IUTEvent
    {
        protected UTEvent(){
			
		}

        public static UTEvent GetEmptyEvent()
        {
            return new UTEvent(null, null, null, null, null, null, null, null);
        }

        public UTEvent(
			DateTime? timestamp, 
			Dictionary<string, string> customValues, 
			string definitionId, 
			string itemId, 
			int? engagementValue, 
			string parentEventId, 
			string text, 
			TimeSpan? duration,
            string type = "event"
		)
        {
			this.CustomValues = customValues;
			this.Timestamp = timestamp;
			this.DefinitionId = definitionId;
			this.ItemId = itemId;
			this.EngagementValue = engagementValue;
			this.ParentEventId = parentEventId;
			this.Text = text;
            this.Duration = duration;
            this.Type = type;
        }
      
        public IUTEvent DeepCopyUTEvent()
        {
            var result = new UTEvent(
                this.Timestamp,
                this.CustomValues,
                this.DefinitionId,
                this.ItemId,
                this.EngagementValue,
                this.ParentEventId,
                this.Text,
                this.Duration
            );

            return result;
        }

		public Dictionary<string, string> CustomValues {
            
			get;
            protected set;
		}

		public string DefinitionId 
        {
            get;
            protected set;
        }

		public string ItemId{
            get;
            protected set;
        }

		public int? EngagementValue
        {
            get;
            protected set;
        }

		public string ParentEventId
        {
            get;
            protected set;
        }

		public string Text
        {
            get;
            protected set;
        }

		public DateTime? Timestamp 
        {
            get;
            protected set;
        }

        public TimeSpan? Duration
        {
            get;
            protected set;
        }

        public string Type
        {
            get;
            protected set;
        }

        public string TrackingInteractionId
        {
            get;
            protected set;
        }

        public void ApplyActiveInteractionWith(string interactionId)
        {
            if (this.TrackingInteractionId == null)
            {
                this.TrackingInteractionId = interactionId;
            }
        }
    }
}
