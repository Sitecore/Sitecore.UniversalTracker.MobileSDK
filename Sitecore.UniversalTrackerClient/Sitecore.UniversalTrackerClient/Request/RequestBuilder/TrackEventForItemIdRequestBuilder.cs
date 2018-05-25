
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System.Collections.Generic;

    public class TrackEventForItemIdRequestBuilder : AbstractEventRequestBuilder<ITrackEventRequest>
    {
        public TrackEventForItemIdRequestBuilder(string itemId)
        {
            ItemIdValidator.ValidateItemId(itemId, this.GetType().Name + ".itemId");
            this.ItemId(itemId);
        }

        public override ITrackEventRequest Build()
        {
#warning @igk check thar all required fields is not null here!!!

            this.EventParametersAccumulator = new UTEvent(
                    this.EventParametersAccumulator.Timestamp,
                    new Dictionary<string, string>(this.FieldsRawValuesByName),
                    this.EventParametersAccumulator.DefinitionId,
                    this.EventParametersAccumulator.ItemId,
                    this.EventParametersAccumulator.EngagementValue,
                    this.EventParametersAccumulator.ParentEventId,
                    this.EventParametersAccumulator.Text,
                    this.EventParametersAccumulator.Duration
                );

            TrackEventParameters result =
                new TrackEventParameters(null, this.EventParametersAccumulator);
            return result;
        }
    }
}

