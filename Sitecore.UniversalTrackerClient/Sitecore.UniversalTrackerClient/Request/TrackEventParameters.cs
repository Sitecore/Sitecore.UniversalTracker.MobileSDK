namespace Sitecore.UniversalTrackerClient.TrackEvent
{
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Session;
    using Sitecore.UniversalTrackerClient.Session.Config;
    using Sitecore.UniversalTrackerClient.UrlBuilder.TrackEvent;

    public class TrackEventParameters : ITrackEventRequest
    {
        public TrackEventParameters(IUTSessionConfig sessionConfig, TrackParameters trackParameters)
        {
            this.SessionConfig = sessionConfig;
            this.TrackParameters = trackParameters;
        }

		public virtual ITrackEventRequest DeepCopyTrackEventRequest()
        {
            IUTSessionConfig connection = null;
            TrackParameters trackParameters = null;

            if (null != this.SessionConfig)
            {
                connection = this.SessionConfig.SessionConfigShallowCopy();
            }

            if (null != this.TrackParameters)
            {
                trackParameters = this.TrackParameters.ShallowCopy();
            }

            return new TrackEventParameters(connection, trackParameters);
        }

		public IBaseEventRequest DeepCopyBaseEventRequest()
		{
			return this.DeepCopyBaseEventRequest();
		}

		public string EventId
        {
            get
            {
                return this.TrackParameters.EventId;
            }
        }

        public IDictionary<string, string> FieldsRawValuesByName
        {
            get
            {
                return this.TrackParameters.FieldsRawValuesByName;
            }
        }

        public IUTSessionConfig SessionConfig { get; private set; }

        public TrackParameters TrackParameters { get; private set; }

    }
}

