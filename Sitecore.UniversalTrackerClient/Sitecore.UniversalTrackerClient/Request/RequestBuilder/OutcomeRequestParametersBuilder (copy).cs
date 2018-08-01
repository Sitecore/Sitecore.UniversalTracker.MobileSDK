
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class OutcomeRequestParametersBuilder : OutcomeAbstractRequestParametersBuilder<ITrackOutcomeRequest>
    {
        private  OutcomeRequestParametersBuilder()
        {
            
        }

        public OutcomeRequestParametersBuilder(string defenitionId)
        {
            ItemIdValidator.ValidateItemId(defenitionId, this.GetType().Name + ".defenitionId");
            this.DefinitionId(defenitionId);
        }

        public override ITrackOutcomeRequest Build()
        {
#warning @igk check that all required fields is not null here!!!

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

            UTOutcome outcome = new UTOutcome(this.EventParametersAccumulator, this.CurrencyCodeValue, this.MonetaryValueValue);

            TrackOutcomeParameters result = new TrackOutcomeParameters(null, outcome);

            return result;
        }

    }
}

