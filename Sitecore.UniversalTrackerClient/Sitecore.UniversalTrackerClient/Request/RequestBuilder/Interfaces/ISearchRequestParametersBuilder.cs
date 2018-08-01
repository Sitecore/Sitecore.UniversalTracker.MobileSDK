
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface ISearchRequestParametersBuilder<T> : IEventRequestParametersBuilder<T>
        where T : class
    {
        ISearchRequestParametersBuilder<T>  Keywords(string keywords);

        #region fluent support

        new ISearchRequestParametersBuilder<T>  AddCustomValues(IDictionary<string, string> customValues);

        new ISearchRequestParametersBuilder<T>  AddCustomValues(string customFieldName, string customFieldValue);

        new ISearchRequestParametersBuilder<T>  DefinitionId(string definitionId);

        new ISearchRequestParametersBuilder<T>  ItemId(string itemId);

        new ISearchRequestParametersBuilder<T>  EngagementValue(int engagementValue);

        new ISearchRequestParametersBuilder<T>  ParentEventId(string parentEventId);

        new ISearchRequestParametersBuilder<T>  Text(string text);

        new ISearchRequestParametersBuilder<T>  Timestamp(DateTime timestamp);

        new ISearchRequestParametersBuilder<T>  Duration(TimeSpan duration);

        #endregion fluent support
    }
}
