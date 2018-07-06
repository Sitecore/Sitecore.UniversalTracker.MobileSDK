
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface IOutcomeRequestParametersBuilder : IEventRequestParametersBuilder<ITrackOutcomeRequest>
    {
        IOutcomeRequestParametersBuilder CurrencyCode(string currencyCode);

        IOutcomeRequestParametersBuilder MonetaryValue(decimal monetaryValue);


        #region fluent support

        new IOutcomeRequestParametersBuilder AddCustomValues(IDictionary<string, string> customValues);

        new IOutcomeRequestParametersBuilder AddCustomValues(string customFieldName, string customFieldValue);

        new IOutcomeRequestParametersBuilder DefinitionId(string definitionId);

        new IOutcomeRequestParametersBuilder ItemId(string itemId);

        new IOutcomeRequestParametersBuilder EngagementValue(int engagementValue);

        new IOutcomeRequestParametersBuilder ParentEventId(string parentEventId);

        new IOutcomeRequestParametersBuilder Text(string text);

        new IOutcomeRequestParametersBuilder Timestamp(DateTime timestamp);

        new IOutcomeRequestParametersBuilder Duration(TimeSpan duration);

        #endregion fluent support
    }
}
