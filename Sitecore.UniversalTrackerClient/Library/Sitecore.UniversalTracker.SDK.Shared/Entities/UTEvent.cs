using System;
using System.Collections.Generic;

namespace Sitecore.UniversalTrackerClient.Entities
{
	public class UTEvent : IUTEvent
    {
        protected UTEvent()
        {
			
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
            string trackingInteractionId,
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
            this.TrackingInteractionId = trackingInteractionId;
            this.type = type;
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
                this.Duration,
                this.TrackingInteractionId,
                this.type
            );

            return result;
        }

		public Dictionary<string, string> CustomValues 
        {
            
			get;
            protected set;
		}

		public string DefinitionId 
        {
            get;
            protected set;
        }

		public string ItemId
        {
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


        #warning @igk - http://tfs4dk1.dk.sitecore.net/tfs/PD-Products-01/Products/_workitems/edit/230819 capitalise Type field when fixed

        #warning FIXME:
        //FIXME: @igk public setter added to support backend bug, it must be replaced with protected

        public string type
        {
            get;
            private set; 
        }

        public string TrackingInteractionId
        {
            get;
            protected set;
        }

    }
}
