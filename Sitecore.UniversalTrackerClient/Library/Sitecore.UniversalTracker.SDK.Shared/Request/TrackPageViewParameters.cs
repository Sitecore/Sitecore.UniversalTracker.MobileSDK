
namespace Sitecore.UniversalTrackerClient.UserRequest
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackPageViewParameters : ITrackPageViewRequest

    {
        public TrackPageViewParameters(IUTSessionConfig sessionConfig, IUTPageView uTPageView)
        {
            this.SessionConfig = sessionConfig;
            this.PageView = uTPageView;
        }

        public virtual ITrackPageViewRequest DeepCopyTrackPageViewRequest()
        {
            IUTSessionConfig connection = null;
            IUTPageView utPageView = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.PageView)
            {
                utPageView = this.PageView;
            }

            return new TrackPageViewParameters(connection, utPageView);
        }

        public IBaseRequest DeepCopyBaseRequest()
        {
            return this.DeepCopyTrackPageViewRequest();
        }

        public IUTPageView PageView { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


    }
}


