namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Validators;

    public abstract class AbstractInteractionRequestBuilder<T> : IInteractionParametersBuilder<T>
  where T : class
    {
        protected Collection<IUTEvent> EventsAggregator = new Collection<IUTEvent>();
        protected UTContact? ContactAggregator = null;

        protected UTInteraction InteractioinParametersAccumulator = UTInteraction.GetEmptyInteraction();

        public IInteractionParametersBuilder<T> AddEvents(Collection<IUTEvent> utEvents)
        {
            BaseValidator.CheckNullAndThrow(utEvents, this.GetType().Name + ".utEvents");

            foreach (IUTEvent singleElem in utEvents)
            {
                this.AddEvents(singleElem);
            }

            return this;
        }

        public IInteractionParametersBuilder<T> AddEvents(IUTEvent utEvent)
        {
            BaseValidator.CheckNullAndThrow(utEvent, this.GetType().Name + ".utEvent");

            bool isDuplicated = DuplicateEntryValidator.IsObjectInTheList(this.EventsAggregator, utEvent);
            if (isDuplicated)
            {
                throw new InvalidOperationException(this.GetType().Name + ".utEvent : duplicate Events are not allowed");
            }

            this.EventsAggregator.Add(utEvent);

            return this;
        }

        public IInteractionParametersBuilder<T> CampaignId(string campaignId)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(campaignId, this.GetType().Name + ".campaignId");
            BaseValidator.CheckForTwiceSetAndThrow(this.InteractioinParametersAccumulator.CampaignId,
                                                   this.GetType().Name + ".InteractioinParametersAccumulator");

            this.InteractioinParametersAccumulator = new UTInteraction(
                campaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId,
                this.InteractioinParametersAccumulator.Contact
            );

            return this;
        }

        public IInteractionParametersBuilder<T> ChannelId(string channelId)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(channelId, this.GetType().Name + ".channelId");
            BaseValidator.CheckForTwiceSetAndThrow(this.InteractioinParametersAccumulator.ChannelId,
                                                   this.GetType().Name + ".InteractioinParametersAccumulator");

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                channelId,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId,
                this.InteractioinParametersAccumulator.Contact
            );

            return this;
        }

        public IInteractionParametersBuilder<T> Initiator(InteractionInitiator initiator)
        {
            
#warning @igk check initiator for twice!???

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.Events,
                initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId,
                this.InteractioinParametersAccumulator.Contact
            );

            return this;
        }

        public IInteractionParametersBuilder<T> UserAgent(string userAgent)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(userAgent, this.GetType().Name + ".userAgent");
            BaseValidator.CheckForTwiceSetAndThrow(this.InteractioinParametersAccumulator.UserAgent,
                                                   this.GetType().Name + ".InteractioinParametersAccumulator");

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                userAgent,
                this.InteractioinParametersAccumulator.VenueId,
                this.InteractioinParametersAccumulator.Contact
            );

            return this;
        }

        public IInteractionParametersBuilder<T> VenueId(string venueId)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(venueId, this.GetType().Name + ".venueId");
            BaseValidator.CheckForTwiceSetAndThrow(this.InteractioinParametersAccumulator.VenueId,
                                                   this.GetType().Name + ".InteractioinParametersAccumulator");

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                venueId,
                this.InteractioinParametersAccumulator.Contact
            );

            return this;
        }

        public IInteractionParametersBuilder<T> Contact(string source, string identifier)
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(source, this.GetType().Name + ".Contact.Source");
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(identifier, this.GetType().Name + ".Contact.Identifier");

            UTContact contact = new UTContact();
            contact.Source = source;
            contact.Identifier = identifier;

            this.ContactAggregator = contact;

            return this;
        }

        public void CheckDefaultsAndThrow(bool denyEmptyEvent = true)
        {
            if (denyEmptyEvent)
            {
                BaseValidator.CheckCollectionForNullAndEmptyOrThrow(this.EventsAggregator, this.GetType().Name + ".utEvents");
            }

            BaseValidator.CheckNullAndThrow(this.ContactAggregator, this.GetType().Name + ".utContact");
            BaseValidator.CheckNullAndThrow(this.InteractioinParametersAccumulator.Initiator, this.GetType().Name + ".utInitiator");
            BaseValidator.CheckNullAndThrow(this.InteractioinParametersAccumulator.ChannelId, this.GetType().Name + ".utChannelId");
        }

        public abstract T Build();

    }
}

