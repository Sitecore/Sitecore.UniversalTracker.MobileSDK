
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class AppLaunchEventRequestBuilder : EventForItemIdRequestBuilder<ITrackEventRequest>

    {
        public AppLaunchEventRequestBuilder() : base()
        {
            base.AddCustomValuesToSet(UTGrammar.UTV1Grammar().AppLaunchedFieldName, DateTime.Now.ToString());
        }

        public override ITrackEventRequest Build()
        {
            return base.Build();
        }
    }
}

