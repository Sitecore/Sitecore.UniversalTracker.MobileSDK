namespace Sitecore.UniversalTrackerClient.Session
{
    public interface IBaseEventRequest
    {
        /// <summary>
        /// Gets the fields that will be present in event.
        /// key   - must contain field name.
        /// value - must contain new field raw value.
        /// </summary>
        /// <returns>
        /// Field name, field raw value pairs.
        /// </returns>
        System.Collections.Generic.IDictionary<string, string> FieldsRawValuesByName { get; }
    }
}