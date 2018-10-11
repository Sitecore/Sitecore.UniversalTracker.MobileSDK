namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;
	using Sitecore.UniversalTrackerClient.Session.Config;

    public class CompleteInteractionParameters : ICompleteInteractionRequest
    {
        public CompleteInteractionParameters(IUTSessionConfig sessionConfig)
        {
            this.SessionConfig = sessionConfig.SessionConfigShallowCopy();
            this.InteractionId = sessionConfig.ActiveInteractionId;
        }

        public virtual ICompleteInteractionRequest DeepCopyCompleteInteractionRequest()
        {
            IUTSessionConfig connection = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            return new CompleteInteractionParameters(connection);
        }

		public IBaseRequest DeepCopyBaseRequest()
		{
            return this.DeepCopyCompleteInteractionRequest();
		}
      
        public IUTSessionConfig SessionConfig { get; private set; }
        public string InteractionId { get; private set; }

    }
}

