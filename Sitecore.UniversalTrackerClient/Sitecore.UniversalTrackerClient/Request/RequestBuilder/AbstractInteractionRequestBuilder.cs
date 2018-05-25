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
        protected UTInteraction InteractioinParametersAccumulator = new UTInteraction(null, null, -1, new DateTime(), new DateTime(), null, InteractionInitiator.Unknown, null, null);


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
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId);

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
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId);

            return this;
        }

        public IInteractionParametersBuilder<T> EndDateTime(DateTime endDateTime)
        {
            #warning @igk check initiator for twice!???

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                endDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId);

            return this;
        }

        public IInteractionParametersBuilder<T> EngagementValue(int engagementValue)
        {
            BaseValidator.CheckForTwiceSetAndThrow(this.InteractioinParametersAccumulator.EngagementValue,
                                                   this.GetType().Name + ".engagementValue");

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                engagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId);

            return this;
        }

        public IInteractionParametersBuilder<T> Initiator(InteractionInitiator initiator)
        {
            
#warning @igk check initiator for twice!???

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId);

            return this;
        }

        public IInteractionParametersBuilder<T> StartDateTime(DateTime startDateTime)
        {
            #warning @igk check initiator for twice!???

            this.InteractioinParametersAccumulator = new UTInteraction(
                this.InteractioinParametersAccumulator.CampaignId,
                this.InteractioinParametersAccumulator.ChannelId,
                this.InteractioinParametersAccumulator.EngagementValue,
                startDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                this.InteractioinParametersAccumulator.VenueId);

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
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                userAgent,
                this.InteractioinParametersAccumulator.VenueId);

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
                this.InteractioinParametersAccumulator.EngagementValue,
                this.InteractioinParametersAccumulator.StartDateTime,
                this.InteractioinParametersAccumulator.EndDateTime,
                this.InteractioinParametersAccumulator.Events,
                this.InteractioinParametersAccumulator.Initiator,
                this.InteractioinParametersAccumulator.UserAgent,
                venueId);

            return this;
        }

        public abstract T Build();

    }
}

