using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackDownloadRequest : IBaseRequest
    {
        IUTDownload Download { get; }

        ITrackDownloadRequest DeepCopyTrackDownloadRequest();
    }
}
