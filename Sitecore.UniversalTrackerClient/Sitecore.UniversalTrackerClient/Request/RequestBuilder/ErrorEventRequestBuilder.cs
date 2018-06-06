
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System.Collections.Generic;

    public class ErrorEventRequestBuilder : EventForItemIdRequestBuilder<ITrackErrorEventRequest>

    {
        public ErrorEventRequestBuilder(string error, string errorDescription) : base()
        {
            base.AddCustomValuesToSet(UTGrammar.UTV1Grammar().ErrorFieldName, error);
            base.AddCustomValuesToSet(UTGrammar.UTV1Grammar().ErrorDescriptionFieldName, errorDescription);
        }

        public override ITrackErrorEventRequest Build()
        {
            return base.Build();
        }
    }
}

