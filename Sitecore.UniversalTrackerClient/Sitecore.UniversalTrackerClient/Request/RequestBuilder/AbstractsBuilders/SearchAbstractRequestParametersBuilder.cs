
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public abstract class SearchAbstractRequestParametersBuilder<T> : AbstractEventRequestBuilder<T>, ISearchRequestParametersBuilder<T>
        where T : class
    {
        protected string KeywordsValue;

        public ISearchRequestParametersBuilder<T> Keywords(string keywords)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.KeywordsValue, this.GetType().Name + ".keywords");

            this.KeywordsValue = keywords;

            return this;
        }

        public abstract override T Build();

#region fluent support

        public new ISearchRequestParametersBuilder<T> DeviceIdentifier(string deviceIdentifier)
        {
            base.DeviceIdentifier(deviceIdentifier);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new ISearchRequestParametersBuilder<T> DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new ISearchRequestParametersBuilder<T> ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new ISearchRequestParametersBuilder<T> Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

#endregion fluent support

    }
}

