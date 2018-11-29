using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackSearchRequest : IBaseRequest
    {
        IUTSearch SearchEvent { get; }

        ITrackSearchRequest DeepCopySearchRequest();
    }
}
