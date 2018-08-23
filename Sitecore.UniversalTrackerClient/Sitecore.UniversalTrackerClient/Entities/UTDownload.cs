
namespace Sitecore.UniversalTrackerClient.Entities
{
    using System;
    using System.Collections.Generic;

    public class UTDownload : UTEvent, IUTDownload
    {
        private UTDownload()
        {

        }

        public UTDownload(IUTEvent uTEvent) : base(
            uTEvent.Timestamp,
            uTEvent.CustomValues,
            uTEvent.DefinitionId,
            uTEvent.ItemId,
            uTEvent.EngagementValue,
            uTEvent.ParentEventId,
            uTEvent.Text,
            uTEvent.Duration,
            uTEvent.TrackingInteractionId,
            "download"
        )
        {

        }

        public IUTDownload DeepCopyUTDownload()
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


            var utDownload = new UTDownload(utEvent);

            return utDownload;
        }
    }
}
