
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class SearchRequestParametersBuilder : AbstractEventRequestBuilder<ITrackSearchRequest>
    {
        private string Keywords;

        private SearchRequestParametersBuilder()
        {

        }

        public SearchRequestParametersBuilder(string keywords)
        {
            BaseValidator.CheckForNullAndEmptyOrThrow(keywords, this.GetType().Name + ".keywords");
            this.Keywords = keywords;
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
                    this.EventParametersAccumulator.Duration,
                    this.EventParametersAccumulator.TrackingInteractionId
                );

            UTSearch utSearch = new UTSearch(
                this.EventParametersAccumulator,
                this.Keywords
            );

            TrackSearchParameters result = new TrackSearchParameters(null, utSearch);

            return result;
        }

    }
}

