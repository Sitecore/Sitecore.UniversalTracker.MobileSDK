
namespace Sitecore.UniversalTrackerClient.UserRequest
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackOutcomeParameters : ITrackOutcomeRequest

    {
        public TrackOutcomeParameters(IUTSessionConfig sessionConfig, IUTOutcome utOutcome)
        {
            this.SessionConfig = sessionConfig;
            this.Outcome = utOutcome;
        }

        public virtual ITrackOutcomeRequest DeepCopyTrackOutcomeRequest()
        {
            IUTSessionConfig connection = null;
            IUTOutcome utOutcome = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.Outcome)
            {
                utOutcome = this.Outcome;
            }

            return new TrackOutcomeParameters(connection, utOutcome);
        }

        public IBaseRequest DeepCopyBaseRequest()
        {
            return this.DeepCopyTrackOutcomeRequest();
        }

        public IUTOutcome Outcome { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


    }
}