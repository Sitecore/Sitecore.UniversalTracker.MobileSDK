
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System.Collections.Generic;

    public class LocationEventRequestBuilder : EventForDefenitionIdRequestBuilder<ITrackLocationEventRequest>

    {
        public LocationEventRequestBuilder(double latitude, double longitude) : base()
        {
            base.AddCustomValues(UTGrammar.UTV1Grammar().LatitudeFieldName, latitude.ToString());
            base.AddCustomValues(UTGrammar.UTV1Grammar().LongitudeFieldName, longitude.ToString());
        }

        public override ITrackLocationEventRequest Build()
        {
            return base.Build();
        }
    }
}

