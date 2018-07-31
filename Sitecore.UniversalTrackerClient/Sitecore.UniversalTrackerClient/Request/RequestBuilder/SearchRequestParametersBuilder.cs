
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class SearchRequestParametersBuilder : AbstractEventRequestBuilder<ITrackSearchRequest>, ISearchRequestParametersBuilder
    {
        private string KeywordsValue;

        private SearchRequestParametersBuilder()
        {

        }

        public SearchRequestParametersBuilder(string defenitionId)
        {
            ItemIdValidator.ValidateItemId(defenitionId, this.GetType().Name + ".defenitionId");
            this.DefinitionId(defenitionId);
        }

        public ISearchRequestParametersBuilder Keywords(string keywords)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.KeywordsValue, this.GetType().Name + ".keywords");

            this.KeywordsValue = keywords;

            return this;
        }

        public override ITrackSearchRequest Build()
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

            UTSearch utSearch = new UTSearch(
                this.EventParametersAccumulator,
                this.KeywordsValue
            );

            TrackSearchParameters result = new TrackSearchParameters(null, utSearch);

            return result;
        }

#region fluent support

        public new ISearchRequestParametersBuilder DeviceIdentifier(string deviceIdentifier)
        {
            base.DeviceIdentifier(deviceIdentifier);

            return this;
        }

        public new ISearchRequestParametersBuilder AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new ISearchRequestParametersBuilder AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new ISearchRequestParametersBuilder DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new ISearchRequestParametersBuilder ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new ISearchRequestParametersBuilder EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new ISearchRequestParametersBuilder ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new ISearchRequestParametersBuilder Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new ISearchRequestParametersBuilder Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new ISearchRequestParametersBuilder Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

#endregion fluent support

    }
}

