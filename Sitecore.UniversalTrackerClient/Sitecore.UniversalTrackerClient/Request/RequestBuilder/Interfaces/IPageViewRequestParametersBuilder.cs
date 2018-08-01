
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface IPageViewRequestParametersBuilder<T> : IEventRequestParametersBuilder<T>
        where T : class
    {
        IPageViewRequestParametersBuilder<T> ItemLanguage(string itemLanguage);

        IPageViewRequestParametersBuilder<T> ItemVersion(int itemVersion);

        IPageViewRequestParametersBuilder<T> Url(string url);

        IPageViewRequestParametersBuilder<T> SitecoreRenderingDevice(string id, string name);

        #region fluent support

        new IPageViewRequestParametersBuilder<T> AddCustomValues(IDictionary<string, string> customValues);

        new IPageViewRequestParametersBuilder<T> AddCustomValues(string customFieldName, string customFieldValue);

        new IPageViewRequestParametersBuilder<T> DefinitionId(string definitionId);

        new IPageViewRequestParametersBuilder<T> ItemId(string itemId);

        new IPageViewRequestParametersBuilder<T> EngagementValue(int engagementValue);

        new IPageViewRequestParametersBuilder<T> ParentEventId(string parentEventId);

        new IPageViewRequestParametersBuilder<T> Text(string text);

        new IPageViewRequestParametersBuilder<T> Timestamp(DateTime timestamp);

        new IPageViewRequestParametersBuilder<T> Duration(TimeSpan duration);

        #endregion fluent support
    }
}
