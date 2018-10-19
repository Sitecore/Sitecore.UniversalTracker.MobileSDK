
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface IOutcomeRequestParametersBuilder<T> : IEventRequestParametersBuilder<T>
        where T: class
    {
        IOutcomeRequestParametersBuilder<T> CurrencyCode(string currencyCode);

        IOutcomeRequestParametersBuilder<T> MonetaryValue(decimal monetaryValue);


        #region fluent support

        new IOutcomeRequestParametersBuilder<T> AddCustomValues(IDictionary<string, string> customValues);

        new IOutcomeRequestParametersBuilder<T> AddCustomValues(string customFieldName, string customFieldValue);

        new IOutcomeRequestParametersBuilder<T> DefinitionId(string definitionId);

        new IOutcomeRequestParametersBuilder<T> ItemId(string itemId);

        new IOutcomeRequestParametersBuilder<T> EngagementValue(int engagementValue);

        new IOutcomeRequestParametersBuilder<T> ParentEventId(string parentEventId);

        new IOutcomeRequestParametersBuilder<T> Text(string text);

        new IOutcomeRequestParametersBuilder<T> Timestamp(DateTime timestamp);

        new IOutcomeRequestParametersBuilder<T> Duration(TimeSpan duration);

        #endregion fluent support
    }
}
