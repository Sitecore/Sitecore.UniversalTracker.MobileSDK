
namespace Sitecore.UniversalTrackerClient.UserRequest
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackDownloadParameters : ITrackDownloadRequest

    {
        public TrackDownloadParameters(IUTSessionConfig sessionConfig, IUTDownload utDownload)
        {
            this.SessionConfig = sessionConfig;
            this.Download = utDownload;
        }

        public virtual ITrackDownloadRequest DeepCopyTrackDownloadRequest()
        {
            IUTSessionConfig connection = null;
            IUTDownload utDownload = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.Download)
            {
                utDownload = this.Download;
            }

            return new TrackDownloadParameters(connection, utDownload);
        }

        public IBaseRequest DeepCopyBaseRequest()
        {
            return this.DeepCopyTrackDownloadRequest();
        }

        public IUTDownload Download { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


    }
}