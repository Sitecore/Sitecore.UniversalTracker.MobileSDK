using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTCampaign : IUTEvent
    {
        /// <summary>
        /// Gets or sets the Campaign Definition ID.
        /// </summary>
        string CampaignDefinitionId { get; }

        IUTCampaign DeepCopyUTCampaign();
    }
}
