using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTDownload : IUTEvent
    {
        IUTDownload DeepCopyUTDownload();
    }
}
