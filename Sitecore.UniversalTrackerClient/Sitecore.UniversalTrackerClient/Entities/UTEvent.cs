using System;
using System.Collections.Generic;

namespace Sitecore.UniversalTrackerClient.Entities
{
	public class UTEvent : IUTEvent
    {
		private UTEvent(DateTime timestamp, Dictionary<string, string> customValues)
        {
			this.CustomValues = customValues;
			this.Timestamp = timestamp;
        }



		public Dictionary<string, string> CustomValues {
			get;
			private set;
		}

		public string DefinitionId {
            get;
            private set;
        }

		public string ItemId => throw new NotImplementedException();

		public int EngagementValue => throw new NotImplementedException();

		public string ParentEventId => throw new NotImplementedException();

		public string Text => throw new NotImplementedException();

		public DateTime Timestamp {
            get;
            private set;
        }

		public TimeSpan Duration => throw new NotImplementedException();
	}
}
