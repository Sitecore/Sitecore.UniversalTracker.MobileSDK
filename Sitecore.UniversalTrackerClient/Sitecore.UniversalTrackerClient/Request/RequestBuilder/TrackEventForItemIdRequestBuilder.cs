
using Sitecore.UniversalTrackerClient.UserRequest;
using Sitecore.UniversalTrackerClient.Validators;

namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{

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
            TrackEventParameters result =
                new TrackEventParameters(null, this.EventParametersAccumulator);
            return result;
        }
    }
}

