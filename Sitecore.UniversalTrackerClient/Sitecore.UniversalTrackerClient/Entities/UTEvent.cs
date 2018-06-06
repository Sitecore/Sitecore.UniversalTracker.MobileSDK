using System;
using System.Collections.Generic;

namespace Sitecore.UniversalTrackerClient.Entities
{
	public class UTEvent : IUTEvent
    {
		private UTEvent(){
			
		}

#warning @igk figure out which parameters is required
        public UTEvent(
			DateTime timestamp, 
			Dictionary<string, string> customValues, 
			string definitionId, 
			string itemId, 
			int engagementValue, 
			string parentEventId, 
			string text, 
			TimeSpan duration
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
			private set;
		}

		public string DefinitionId {
            get;
            private set;
        }

		public string ItemId{
            get;
            private set;
        }

		public int EngagementValue{
            get;
            private set;
        }

		public string ParentEventId{
            get;
            private set;
        }

		public string Text{
            get;
            private set;
        }

		public DateTime Timestamp {
            get;
            private set;
        }

		public TimeSpan Duration{
            get;
            private set;
        }

    }
}
