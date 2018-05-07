namespace Sitecore.UniversalTrackerClient.TrackEvent
{
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Session;
    using Sitecore.UniversalTrackerClient.UrlBuilder.TrackEvent;

    public class TrackEventParameters : ITrackEventRequest
    {
        public TrackEventParameters(IUTSessionConfig sessionSettings, TrackParameters trackParameters)
        {
            this.SessionSettings = sessionSettings;
            this.TrackParameters = trackParameters;
        }

        public virtual ITrackEventRequest DeepCopyTrackEventRequest()
        {
            IUTSessionConfig connection = null;
            TrackParameters trackParameters = null;

            if (null != this.SessionSettings)
            {
                connection = this.SessionSettings.SessionConfigShallowCopy();
            }

            if (null != this.TrackParameters)
            {
                trackParameters = this.TrackParameters.ShallowCopy();
            }

            return new TrackEventParameters(connection, trackParameters);
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

        public IUTSessionConfig SessionSettings { get; private set; }

        public TrackParameters TrackParameters { get; private set; }

    }
}

