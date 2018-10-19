namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;
	using Sitecore.UniversalTrackerClient.Session.Config;

	public class TrackEventParameters : 
                    ITrackEventRequest,
                    ITrackLocationEventRequest,
                    ITrackPageClosedEventRequest,
                    ITrackPageOpenedEventRequest,
                    ITrackErrorEventRequest

    {
		public TrackEventParameters(IUTSessionConfig sessionConfig,  IUTEvent uTEvent)
        {
            this.SessionConfig = sessionConfig;
			this.Event = uTEvent;
        }

		public virtual ITrackEventRequest DeepCopyTrackEventRequest()
        {
            IUTSessionConfig connection = null;
			IUTEvent uTEvent = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

			if (null != this.Event)
            {
				uTEvent = this.Event;
            }

			return new TrackEventParameters(connection, uTEvent);
        }

		public IBaseRequest DeepCopyBaseRequest()
		{
			return this.DeepCopyBaseRequest();
		}
      
		public IUTEvent Event { get; private set; }

        public IUTSessionConfig SessionConfig { get; private set; }


	}
}

