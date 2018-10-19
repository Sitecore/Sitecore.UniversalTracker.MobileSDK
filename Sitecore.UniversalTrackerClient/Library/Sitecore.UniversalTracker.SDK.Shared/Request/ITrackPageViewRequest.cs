using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackPageViewRequest : IBaseRequest
    {
        IUTPageView PageView { get; }

        ITrackPageViewRequest DeepCopyTrackPageViewRequest();
    }
}
