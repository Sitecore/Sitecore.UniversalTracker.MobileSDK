using System;

namespace Sitecore.UniversalTrackerClient.Session
{
    public interface ISitecoreUTSession :
    IDisposable,
    ISitecoreUTSessionState,
    ISitecoreUTSessionActions
    {

    }
}