using System;
using System.Collections.ObjectModel;

namespace Sitecore.UniversalTrackerClient.Entities
{
	public class UTInteraction : IUTInteraction
    {
		private UTInteraction()
        {
        }

		public UTInteraction(
			string campaignId, 
			string channelId, 
			int engagementValue, 
			DateTime startDateTime, 
			DateTime endDateTime, 
			Collection<IUTEvent> events, 
			InteractionInitiator initiator, 
			string userAgent,
			string venueId
		)
        {
			this.CampaignId = campaignId;
			this.ChannelId = channelId;
			this.EngagementValue = engagementValue;
			this.StartDateTime = startDateTime;
			this.EndDateTime = endDateTime;
			this.Events = events;
			this.Initiator = initiator;
			this.UserAgent = userAgent;
			this.VenueId = venueId;
        }

        public IUTInteraction DeepCopyUTInteraction()
        {
            var result = new UTInteraction(
                this.CampaignId,
                this.ChannelId,
                this.EngagementValue,
                this.StartDateTime,
                this.EndDateTime,
                this.Events,
                this.Initiator,
                this.UserAgent,
                this.VenueId
            );

            return result;
        }

		public string CampaignId
        {
            get;
            private set;
        }

		public string ChannelId
        {
            get;
            private set;
        }

		public int EngagementValue
        {
            get;
            private set;
        }

		public DateTime StartDateTime
        {
            get;
            private set;
        }

		public DateTime EndDateTime
        {
            get;
            private set;
        }

		public Collection<IUTEvent> Events
        {
            get;
            private set;
        }

		public InteractionInitiator Initiator
        {
            get;
            private set;
        }

		public string UserAgent
        {
            get;
            private set;
        }

		public string VenueId
        {
            get;
            private set;
        }
	}
}
