
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class OutcomeRequestParametersBuilder : AbstractEventRequestBuilder<ITrackOutcomeRequest>, IOutcomeRequestParametersBuilder
    {
        private string CurrencyCodeValue;
        private decimal MonetaryValueValue;

        private OutcomeRequestParametersBuilder()
        {

        }

        public OutcomeRequestParametersBuilder(string defenitionId)
        {
            ItemIdValidator.ValidateItemId(defenitionId, this.GetType().Name + ".defenitionId");
            this.DefinitionId(defenitionId);
        }

        public IOutcomeRequestParametersBuilder CurrencyCode(string currencyCode)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.CurrencyCodeValue,
                                                   this.GetType().Name + ".currencyCode");

            this.CurrencyCodeValue = currencyCode;

            return this;
        }

        public IOutcomeRequestParametersBuilder MonetaryValue(decimal monetaryValue)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.MonetaryValueValue,
                                                   this.GetType().Name + ".monetaryValue");

            this.MonetaryValueValue = monetaryValue;

            return this;
        }

        public override ITrackOutcomeRequest Build()
        {
#warning @igk check thar all required fields is not null here!!!

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

            TrackOutcomeParameters result =
                new TrackOutcomeParameters(null, outcome);

            return result;
        }

#region fluent support

        public new IOutcomeRequestParametersBuilder AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new IOutcomeRequestParametersBuilder AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new IOutcomeRequestParametersBuilder DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new IOutcomeRequestParametersBuilder ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new IOutcomeRequestParametersBuilder EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new IOutcomeRequestParametersBuilder ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new IOutcomeRequestParametersBuilder Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new IOutcomeRequestParametersBuilder Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new IOutcomeRequestParametersBuilder Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

#endregion fluent support

    }
}

