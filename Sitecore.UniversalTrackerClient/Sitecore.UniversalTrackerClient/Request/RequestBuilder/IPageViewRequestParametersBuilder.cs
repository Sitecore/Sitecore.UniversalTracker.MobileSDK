
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface IPageViewRequestParametersBuilder : IEventRequestParametersBuilder<ITrackPageViewRequest>
    {
        IPageViewRequestParametersBuilder ItemLanguage(string itemLanguage);

        IPageViewRequestParametersBuilder ItemVersion(int itemVersion);

        IPageViewRequestParametersBuilder Url(string url);

        IPageViewRequestParametersBuilder SitecoreRenderingDevice(string id, string name);

        #region fluent support

        new IPageViewRequestParametersBuilder AddCustomValues(IDictionary<string, string> customValues);

        new IPageViewRequestParametersBuilder AddCustomValues(string customFieldName, string customFieldValue);

        new IPageViewRequestParametersBuilder DefinitionId(string definitionId);

        new IPageViewRequestParametersBuilder ItemId(string itemId);

        new IPageViewRequestParametersBuilder EngagementValue(int engagementValue);

        new IPageViewRequestParametersBuilder ParentEventId(string parentEventId);

        new IPageViewRequestParametersBuilder Text(string text);

        new IPageViewRequestParametersBuilder Timestamp(DateTime timestamp);

        new IPageViewRequestParametersBuilder Duration(TimeSpan duration);

        #endregion fluent support
    }
}
