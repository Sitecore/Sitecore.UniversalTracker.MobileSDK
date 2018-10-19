
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public abstract class PageViewAbstractRequestParametersBuilder<T> : AbstractEventRequestBuilder<T>, IPageViewRequestParametersBuilder<T>
        where T : class
    {
        protected string ItemLanguageValue;
        protected string UrlValue;
        protected int ItemVersionValue;
        protected SitecoreDeviceData SitecoreRenderingDeviceValue;


        public IPageViewRequestParametersBuilder<T> ItemLanguage(string itemLanguage)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.ItemLanguageValue, this.GetType().Name + ".itemLanguage");

            this.ItemLanguageValue = itemLanguage;

            return this;
        }

        public IPageViewRequestParametersBuilder<T> Url(string url)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.UrlValue, this.GetType().Name + ".url");
            
            this.UrlValue = url;

            return this;
        }

        public IPageViewRequestParametersBuilder<T> ItemVersion(int itemVersion)
        {
         
            this.ItemVersionValue = itemVersion;

            return this;
        }

        public IPageViewRequestParametersBuilder<T> SitecoreRenderingDevice(string id, string Name)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.SitecoreRenderingDeviceValue, this.GetType().Name + ".sitecoreRenderingDeviceValue");

            this.SitecoreRenderingDeviceValue = new SitecoreDeviceData(id, Name);

            return this;
        }

        public abstract override T Build();

#region fluent support

        public new IPageViewRequestParametersBuilder<T> DeviceIdentifier(string deviceIdentifier)
        {
            base.DeviceIdentifier(deviceIdentifier);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new IPageViewRequestParametersBuilder<T> DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new IPageViewRequestParametersBuilder<T> ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new IPageViewRequestParametersBuilder<T> Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

#endregion fluent support

    }
}

