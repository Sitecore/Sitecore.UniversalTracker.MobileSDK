using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackOutcomeRequest : IBaseRequest
    {
#warning not implemented!!!

        IUTOutcome Outcome { get; }

        ITrackOutcomeRequest DeepCopyTrackOutcomeRequest();
    }
}
