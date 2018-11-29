using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTGoal : IUTEvent
    {
        IUTGoal DeepCopyUTGoal();
    }
}
