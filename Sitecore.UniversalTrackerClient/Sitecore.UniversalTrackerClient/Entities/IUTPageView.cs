namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTPageView : IUTEvent
    {
        /// <summary>
        /// Item Language.
        /// </summary>
        string ItemLanguage { get; }

        /// <summary>
        /// Item Version.
        /// </summary>
        int? ItemVersion { get; }

        /// <summary>
        /// URL.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Sitecore Rendering Device.
        /// </summary>
        SitecoreDeviceData SitecoreRenderingDevice { get; }

        IUTPageView DeepCopyUTPageView();
    }

    public class SitecoreDeviceData
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public SitecoreDeviceData(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}