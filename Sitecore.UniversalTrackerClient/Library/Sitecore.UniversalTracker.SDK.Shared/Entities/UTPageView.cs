using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public class UTPageView : UTEvent, IUTPageView
    {

        private UTPageView()
        {
        }

        public UTPageView(IUTEvent utEvent, string itemLanguage, int? itemVersion, string url, SitecoreDeviceData sitecoreRenderingDevice) 
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
                "pageview"
            )
        {
            this.ItemLanguage = itemLanguage;
            this.ItemVersion = itemVersion;
            this.Url = url;
            this.SitecoreRenderingDevice = sitecoreRenderingDevice;
        }

        public string ItemLanguage
        {
            get;
            private set;
        }

        public int? ItemVersion
        {
            get;
            private set;
        }

        public string Url
        {
            get;
            private set;
        }

        public SitecoreDeviceData SitecoreRenderingDevice
        {
            get;
            private set;
        }

        public IUTPageView DeepCopyUTPageView()
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


            var utPageView = new UTPageView(
                utEvent,
                this.ItemLanguage,
                this.ItemVersion,
                this.Url,
                this.SitecoreRenderingDevice
            );

            return utPageView;
        }

       
    }
}
