
namespace Sitecore.UniversalTrackerClient.UserRequest
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackGoalParameters : ITrackGoalRequest

    {
        public TrackGoalParameters(IUTSessionConfig sessionConfig, IUTGoal utGoal)
        {
            this.SessionConfig = sessionConfig;
            this.Goal = utGoal;
        }

        public virtual ITrackGoalRequest DeepCopyTrackGoalRequest()
        {
            IUTSessionConfig connection = null;
            IUTGoal utGoal = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.Goal)
            {
                utGoal = this.Goal;
            }

            return new TrackGoalParameters(connection, utGoal);
        }

        public IBaseRequest DeepCopyBaseRequest()
        {
            return this.DeepCopyTrackGoalRequest();
        }

        public IUTGoal Goal { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


    }
}