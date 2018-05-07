namespace Sitecore.UniversalTrackerClient.UrlBuilder.TrackEvent
{
    using System.Collections.Generic;

    public class TrackParameters
    {
        public TrackParameters(string eventId, IDictionary<string, string> fieldsRawValuesByName)
        {
            this.EventId = eventId;            
            this.FieldsRawValuesByName = fieldsRawValuesByName;
        }

        public TrackParameters ShallowCopy()
        {
            return new TrackParameters(this.EventId, this.FieldsRawValuesByName);
        }

        public string EventId { get; private set; }
        public IDictionary<string, string> FieldsRawValuesByName { get; private set; }
    }
}

