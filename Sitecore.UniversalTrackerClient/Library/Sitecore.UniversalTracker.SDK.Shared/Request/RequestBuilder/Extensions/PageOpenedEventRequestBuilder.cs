
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Helpers;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using System;

    public class PageOpenedEventRequestBuilder : EventForDefenitionIdRequestBuilder<ITrackPageOpenedEventRequest>

    {
        public PageOpenedEventRequestBuilder(string padeId, DateTime timeStamp) : base()
        {
            string unixTimestampString = DateTimeHelper.ConvertToUnixTime(timeStamp).ToString();

            base.AddCustomValues(UTGrammar.UTV1Grammar().PageOpenedFieldName, unixTimestampString);
            base.AddCustomValues(UTGrammar.UTV1Grammar().PageIdFieldName, padeId);
        }

        public override ITrackPageOpenedEventRequest Build()
        {
            return base.Build();
        }
    }
}

