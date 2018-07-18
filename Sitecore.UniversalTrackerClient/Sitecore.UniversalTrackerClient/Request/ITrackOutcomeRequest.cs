using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackOutcomeRequest : IBaseRequest
    {
        IUTOutcome Outcome { get; }

        ITrackOutcomeRequest DeepCopyTrackOutcomeRequest();
    }
}
