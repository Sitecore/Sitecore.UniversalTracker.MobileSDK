using System;
using Sitecore.UniversalTrackerClient.Entities;

namespace Sitecore.UniversalTrackerClient.UserRequest
{
    public interface ITrackGoalRequest : IBaseRequest
    {
        IUTGoal Goal { get; }

        ITrackGoalRequest DeepCopyTrackGoalRequest();
    }
}
