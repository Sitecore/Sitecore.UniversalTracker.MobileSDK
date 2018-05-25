namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;
	using Sitecore.UniversalTrackerClient.Session.Config;

    public class TrackInteractionParameters : ITrackInteractionRequest
    {
        public TrackInteractionParameters(IUTSessionConfig sessionConfig,  IUTInteraction uTInteraction)
        {
            this.SessionConfig = sessionConfig;
            this.Interaction = uTInteraction;
        }

        public virtual ITrackInteractionRequest DeepCopyTrackInteractionRequest()
        {
            IUTSessionConfig connection = null;
            IUTInteraction uTInteraction = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.Interaction)
            {
                uTInteraction = this.Interaction;
            }

            return new TrackInteractionParameters(connection, uTInteraction);
        }

		public IBaseRequest DeepCopyBaseRequest()
		{
			return this.DeepCopyBaseRequest();
		}
      
        public IUTInteraction Interaction { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


	}
}

