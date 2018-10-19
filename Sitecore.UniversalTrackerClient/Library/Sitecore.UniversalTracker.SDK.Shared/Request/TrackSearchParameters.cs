
namespace Sitecore.UniversalTrackerClient.UserRequest
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackSearchParameters : ITrackSearchRequest

    {
        public TrackSearchParameters(IUTSessionConfig sessionConfig, IUTSearch utSearch)
        {
            this.SessionConfig = sessionConfig;
            this.SearchEvent = utSearch;
        }

        public virtual ITrackSearchRequest DeepCopySearchRequest()
        {
            IUTSessionConfig connection = null;
            IUTSearch utSearch = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.SearchEvent)
            {
                utSearch = this.SearchEvent;
            }

            return new TrackSearchParameters(connection, utSearch);
        }

        public IBaseRequest DeepCopyBaseRequest()
        {
            return this.DeepCopySearchRequest();
        }

        public IUTSearch SearchEvent { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


    }
}


