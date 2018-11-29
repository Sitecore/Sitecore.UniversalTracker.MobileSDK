
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Helpers;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using System;

    public class PageClosedEventRequestBuilder : EventForDefenitionIdRequestBuilder<ITrackPageClosedEventRequest>

    {
        public PageClosedEventRequestBuilder(string padeId, DateTime timeStamp) : base()
        {
            base.AddCustomValues(UTGrammar.UTV1Grammar().PageClosedFieldName, DateTimeHelper.ConvertToUnixTime(timeStamp).ToString());
            base.AddCustomValues(UTGrammar.UTV1Grammar().PageIdFieldName, padeId);
        }

        public override ITrackPageClosedEventRequest Build()
        {
            return base.Build();
        }
    }
}

