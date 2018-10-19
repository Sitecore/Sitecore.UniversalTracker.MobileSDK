
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public abstract class OutcomeAbstractRequestParametersBuilder<T> : AbstractEventRequestBuilder<T>, IOutcomeRequestParametersBuilder<T>
        where T : class
    {
        protected string CurrencyCodeValue;
        protected decimal MonetaryValueValue;


        public IOutcomeRequestParametersBuilder<T> CurrencyCode(string currencyCode)
        {

            BaseValidator.CheckForTwiceSetAndThrow(this.CurrencyCodeValue,
                                                   this.GetType().Name + ".currencyCode");

            this.CurrencyCodeValue = currencyCode;

            return this;
        }

        public IOutcomeRequestParametersBuilder<T> MonetaryValue(decimal monetaryValue)
        {
         
            this.MonetaryValueValue = monetaryValue;

            return this;
        }

        public abstract override T Build();

#region fluent support

        public new IOutcomeRequestParametersBuilder<T> AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> DeviceIdentifier(string deviceIdentifier)
        {
            base.DeviceIdentifier(deviceIdentifier);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new IOutcomeRequestParametersBuilder<T> DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new IOutcomeRequestParametersBuilder<T> ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new IOutcomeRequestParametersBuilder<T> Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

#endregion fluent support

    }
}

