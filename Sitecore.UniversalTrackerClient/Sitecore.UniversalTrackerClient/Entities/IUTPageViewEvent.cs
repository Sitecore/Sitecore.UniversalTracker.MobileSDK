using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTPageViewEvent : IUTEvent
    {
        /// <summary>
        /// Item Language.
        /// </summary>
        string ItemLanguage { get; }

        /// <summary>
        /// Item Version.
        /// </summary>
        int ItemVersion { get; }

        /// <summary>
        /// URL, if needed
        /// </summary>
        string Url { get; }
    }
}
