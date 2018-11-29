
namespace Sitecore.UniversalTrackerClient.UserRequest
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackCampaignParameters : ITrackCampaignRequest

    {
        public TrackCampaignParameters(IUTSessionConfig sessionConfig, IUTCampaign utCampaign)
        {
            this.SessionConfig = sessionConfig;
            this.Campaign = utCampaign;
        }

        public virtual ITrackCampaignRequest DeepCopyTrackCampaignRequest()
        {
            IUTSessionConfig connection = null;
            IUTCampaign utCampaign = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.Campaign)
            {
                utCampaign = this.Campaign;
            }

            return new TrackCampaignParameters(connection, utCampaign);
        }

        public IBaseRequest DeepCopyBaseRequest()
        {
            return this.DeepCopyTrackCampaignRequest();
        }

        public IUTCampaign Campaign { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


    }
}