
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface ISearchRequestParametersBuilder : IEventRequestParametersBuilder<ITrackSearchRequest>
    {
        ISearchRequestParametersBuilder Keywords(string keywords);

        #region fluent support

        new ISearchRequestParametersBuilder AddCustomValues(IDictionary<string, string> customValues);

        new ISearchRequestParametersBuilder AddCustomValues(string customFieldName, string customFieldValue);

        new ISearchRequestParametersBuilder DefinitionId(string definitionId);

        new ISearchRequestParametersBuilder ItemId(string itemId);

        new ISearchRequestParametersBuilder EngagementValue(int engagementValue);

        new ISearchRequestParametersBuilder ParentEventId(string parentEventId);

        new ISearchRequestParametersBuilder Text(string text);

        new ISearchRequestParametersBuilder Timestamp(DateTime timestamp);

        new ISearchRequestParametersBuilder Duration(TimeSpan duration);

        #endregion fluent support
    }
}
