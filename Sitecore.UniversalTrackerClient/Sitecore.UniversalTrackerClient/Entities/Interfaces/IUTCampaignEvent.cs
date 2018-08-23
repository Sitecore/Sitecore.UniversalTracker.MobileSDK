using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    /// <summary>
    /// The ID of the campaign event's definition.
    /// </summary>
    //public static readonly Guid EventDefinitionId = new Guid("F358D040-256F-4FC6-B2A1-739ACA2B2983");

    public interface IUTCampaignEvent : IUTEvent
    {
        string CampaignDefinitionId { get; }
    }
}
