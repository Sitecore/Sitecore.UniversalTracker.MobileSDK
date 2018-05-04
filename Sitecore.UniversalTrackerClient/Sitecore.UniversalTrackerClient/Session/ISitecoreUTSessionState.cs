using System;

namespace Sitecore.UniversalTrackerClient.Session
{
    public interface ISitecoreUTSessionState : IDisposable
    {
        IUTSessionConfig Config { get; }

        string UTTokenValue { get; }
    }
}