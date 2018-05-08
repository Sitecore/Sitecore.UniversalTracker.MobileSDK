namespace Sitecore.UniversalTrackerClient.Session
{
    using System;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public interface ISitecoreUTSessionState : IDisposable
    {
        IUTSessionConfig Config { get; }

        string UTTokenValue { get; }
    }
}