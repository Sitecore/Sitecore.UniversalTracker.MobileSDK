
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class AppFinishedEventRequestBuilder : EventForItemIdRequestBuilder<ITrackEventRequest>

    {
        public AppFinishedEventRequestBuilder() : base()
        {
            base.AddCustomValuesToSet(UTGrammar.UTV1Grammar().AppFinishedFieldName, DateTime.Now.ToString());
        }

        public override ITrackEventRequest Build()
        {
            return base.Build();
        }
    }
}

