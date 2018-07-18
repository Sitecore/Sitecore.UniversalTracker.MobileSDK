
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class PageViewRequestParametersBuilder : AbstractEventRequestBuilder<ITrackPageViewRequest>, IPageViewRequestParametersBuilder
    {
        private string ItemLanguageValue;
        private string UrlValue;
        private int ItemVersionValue;
        private SitecoreDeviceData SitecoreRenderingDeviceValue;
        private PageViewRequestParametersBuilder()
        {

        }

        public PageViewRequestParametersBuilder(string defenitionId)
        {
            ItemIdValidator.ValidateItemId(defenitionId, this.GetType().Name + ".defenitionId");
            this.DefinitionId(defenitionId);
        }

        public IPageViewRequestParametersBuilder ItemLanguage(string itemLanguage)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.ItemLanguageValue, this.GetType().Name + ".itemLanguage");

            this.ItemLanguageValue = itemLanguage;

            return this;
        }

        public IPageViewRequestParametersBuilder Url(string url)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.UrlValue, this.GetType().Name + ".url");
            
            this.UrlValue = url;

            return this;
        }

        public IPageViewRequestParametersBuilder ItemVersion(int itemVersion)
        {
         
            this.ItemVersionValue = itemVersion;

            return this;
        }

        public IPageViewRequestParametersBuilder SitecoreRenderingDevice(string id, string Name)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.SitecoreRenderingDeviceValue, this.GetType().Name + ".sitecoreRenderingDeviceValue");

            this.SitecoreRenderingDeviceValue = new SitecoreDeviceData(id, Name);

            return this;
        }

        public override ITrackPageViewRequest Build()
        {
            Dictionary<string, string> customParameters = null;

            if (this.FieldsRawValuesByName != null)
            {
                customParameters = new Dictionary<string, string>(this.FieldsRawValuesByName);
            }

            this.EventParametersAccumulator = new UTEvent(
                    this.EventParametersAccumulator.Timestamp,
                    customParameters,
                    this.EventParametersAccumulator.DefinitionId,
                    this.EventParametersAccumulator.ItemId,
                    this.EventParametersAccumulator.EngagementValue,
                    this.EventParametersAccumulator.ParentEventId,
                    this.EventParametersAccumulator.Text,
                    this.EventParametersAccumulator.Duration
                );

            UTPageView pageView = new UTPageView(
                this.EventParametersAccumulator,
                this.ItemLanguageValue,
                this.ItemVersionValue,
                this.UrlValue,
                this.SitecoreRenderingDeviceValue
            );

            TrackPageViewParameters result = new TrackPageViewParameters(null, pageView);

            return result;
        }

#region fluent support

        public new IPageViewRequestParametersBuilder AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new IPageViewRequestParametersBuilder AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new IPageViewRequestParametersBuilder DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new IPageViewRequestParametersBuilder ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new IPageViewRequestParametersBuilder EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new IPageViewRequestParametersBuilder ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new IPageViewRequestParametersBuilder Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new IPageViewRequestParametersBuilder Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new IPageViewRequestParametersBuilder Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

#endregion fluent support

    }
}

