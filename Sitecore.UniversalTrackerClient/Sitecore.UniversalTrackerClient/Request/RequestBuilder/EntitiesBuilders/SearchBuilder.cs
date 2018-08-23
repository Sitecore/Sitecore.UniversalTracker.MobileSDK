
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Validators;

    internal class SearchBuilder : AbstractEventRequestBuilder<IUTSearch>
    {
        private string Keywords;

        public SearchBuilder(string keywords)
        {
            BaseValidator.CheckForNullAndEmptyOrThrow(keywords, this.GetType().Name + ".keywords");
            this.Keywords = keywords;
        }

        public override IUTSearch Build()
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

            var result = new UTSearch(this.EventParametersAccumulator, this.Keywords);

            return result;
        }
    }
}