namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Validators;

    public abstract class AbstractEventRequestBuilder<T> : IEventrequestParametersBuilder<T>
  where T : class
    {

        protected UTEvent EventParametersAccumulator = new UTEvent(new DateTime(), null, null, null, -1, null, null, new TimeSpan());

        protected IDictionary<string, string> FieldsRawValuesByName;

        public IEventrequestParametersBuilder<T> AddCustomValuesToSet(IDictionary<string, string> customValues)
        {
            BaseValidator.CheckNullAndThrow(customValues, this.GetType().Name + ".customFieldsValues");

            if (customValues.Count == 0)
            {
                return this;
            }

            foreach (var fieldElem in FieldsRawValuesByName)
            {
                this.AddCustomValuesToSet(fieldElem.Key, fieldElem.Value);
            }

            return this;
        }

        public IEventrequestParametersBuilder<T> AddCustomValuesToSet(string customFieldName, string customFieldValue)
        {
            BaseValidator.CheckForNullAndEmptyOrThrow(customFieldName, this.GetType().Name + ".customFieldName");

            BaseValidator.CheckForNullAndEmptyOrThrow(customFieldValue, this.GetType().Name + ".customFieldValue");

            if (null == this.FieldsRawValuesByName)
            {
                Dictionary<string, string> newFields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                this.FieldsRawValuesByName = newFields;
            }

            string lowerCaseField = customFieldName.ToLowerInvariant();

            bool keyIsDuplicated = DuplicateEntryValidator.IsDuplicatedFieldsInTheDictionary(this.FieldsRawValuesByName, lowerCaseField);
            if (keyIsDuplicated)
            {
                throw new InvalidOperationException(this.GetType().Name + ".customFieldValue : duplicate fields are not allowed");
            }

            this.FieldsRawValuesByName.Add(lowerCaseField, customFieldValue);

            return this;
        }


        public IEventrequestParametersBuilder<T> DefinitionId(string definitionId)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(definitionId, this.GetType().Name + ".definitionId");
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.DefinitionId,
                                                   this.GetType().Name + ".EventParametersAccumulator");

            this.EventParametersAccumulator = new UTEvent(
                this.EventParametersAccumulator.Timestamp,
                this.EventParametersAccumulator.CustomValues,
                definitionId,
                this.EventParametersAccumulator.ItemId,
                this.EventParametersAccumulator.EngagementValue,
                this.EventParametersAccumulator.ParentEventId,
                this.EventParametersAccumulator.Text,
                this.EventParametersAccumulator.Duration
            );

            return this;
        }


        public IEventrequestParametersBuilder<T> ItemId(string itemId)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(itemId, this.GetType().Name + ".itemId");
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.ItemId,
                                                   this.GetType().Name + ".itemId");

            this.EventParametersAccumulator = new UTEvent(
                this.EventParametersAccumulator.Timestamp,
                this.EventParametersAccumulator.CustomValues,
                this.EventParametersAccumulator.DefinitionId,
                itemId,
                this.EventParametersAccumulator.EngagementValue,
                this.EventParametersAccumulator.ParentEventId,
                this.EventParametersAccumulator.Text,
                this.EventParametersAccumulator.Duration
            );

            return this;
        }

        public IEventrequestParametersBuilder<T> EngagementValue(int engagementValue)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.EngagementValue,
                                                   this.GetType().Name + ".engagementValue");

            this.EventParametersAccumulator = new UTEvent(
                this.EventParametersAccumulator.Timestamp,
                this.EventParametersAccumulator.CustomValues,
                this.EventParametersAccumulator.DefinitionId,
                this.EventParametersAccumulator.ItemId,
                engagementValue,
                this.EventParametersAccumulator.ParentEventId,
                this.EventParametersAccumulator.Text,
                this.EventParametersAccumulator.Duration
            );

            return this;
        }

        public IEventrequestParametersBuilder<T> ParentEventId(string parentEventId)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(parentEventId, this.GetType().Name + ".parentEventId");
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.ParentEventId,
                                                   this.GetType().Name + ".parentEventId");

            this.EventParametersAccumulator = new UTEvent(
                this.EventParametersAccumulator.Timestamp,
                this.EventParametersAccumulator.CustomValues,
                this.EventParametersAccumulator.DefinitionId,
                this.EventParametersAccumulator.ItemId,
                this.EventParametersAccumulator.EngagementValue,
                parentEventId,
                this.EventParametersAccumulator.Text,
                this.EventParametersAccumulator.Duration
            );

            return this;
        }

        public IEventrequestParametersBuilder<T> Text(string text)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(text, this.GetType().Name + ".text");
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.Text,
                                                   this.GetType().Name + ".text");

            this.EventParametersAccumulator = new UTEvent(
                this.EventParametersAccumulator.Timestamp,
                this.EventParametersAccumulator.CustomValues,
                this.EventParametersAccumulator.DefinitionId,
                this.EventParametersAccumulator.ItemId,
                this.EventParametersAccumulator.EngagementValue,
                this.EventParametersAccumulator.ParentEventId,
                text,
                this.EventParametersAccumulator.Duration
            );

            return this;
        }

        public IEventrequestParametersBuilder<T> Timestamp(DateTime timestamp)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.Timestamp,
                                                   this.GetType().Name + ".timestamp");

            this.EventParametersAccumulator = new UTEvent(
                timestamp,
                this.EventParametersAccumulator.CustomValues,
                this.EventParametersAccumulator.DefinitionId,
                this.EventParametersAccumulator.ItemId,
                this.EventParametersAccumulator.EngagementValue,
                this.EventParametersAccumulator.ParentEventId,
                this.EventParametersAccumulator.Text,
                this.EventParametersAccumulator.Duration
            );

            return this;
        }

        public IEventrequestParametersBuilder<T> Duration(TimeSpan duration)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.EventParametersAccumulator.Duration,
                                                   this.GetType().Name + ".duration");

            this.EventParametersAccumulator = new UTEvent(
                this.EventParametersAccumulator.Timestamp,
                this.EventParametersAccumulator.CustomValues,
                this.EventParametersAccumulator.DefinitionId,
                this.EventParametersAccumulator.ItemId,
                this.EventParametersAccumulator.EngagementValue,
                this.EventParametersAccumulator.ParentEventId,
                this.EventParametersAccumulator.Text,
                duration
            );

            return this;
        }

        public abstract T Build();
       
    }
}

