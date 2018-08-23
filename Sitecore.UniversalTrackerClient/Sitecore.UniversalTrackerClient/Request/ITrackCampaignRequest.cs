using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackCampaignRequest : IBaseRequest
    {
        IUTCampaign Campaign { get; }

        ITrackCampaignRequest DeepCopyTrackCampaignRequest();
    }
}
