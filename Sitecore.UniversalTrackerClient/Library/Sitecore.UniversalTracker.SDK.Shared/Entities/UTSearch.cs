using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public class UTSearch : UTEvent, IUTSearch
    {

        private UTSearch()
        {
        }

        public UTSearch(IUTEvent utEvent, string keywords) 
            : base  (
                utEvent.Timestamp,
                utEvent.CustomValues,
                utEvent.DefinitionId,
                utEvent.ItemId,
                utEvent.EngagementValue,
                utEvent.ParentEventId,
                utEvent.Text,
                utEvent.Duration,
                utEvent.TrackingInteractionId,
                "search"
            )
        {
            this.Keywords = keywords;
        }

        public string Keywords
        {
            get;
            private set;
        }

        public IUTSearch DeepCopyUTSearch()
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


            var utSearch = new UTSearch(
                utEvent,
                this.Keywords
            );

            return utSearch;
        }

       
    }
}
