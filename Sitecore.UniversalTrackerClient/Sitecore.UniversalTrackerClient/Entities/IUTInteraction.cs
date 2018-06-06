
namespace Sitecore.UniversalTrackerClient.Entities
{
    using System;
    using System.Collections.ObjectModel;

    public interface IUTInteraction
    {

        IUTInteraction DeepCopyUTInteraction();

		/// <summary>
        /// Returns campaign's GUID.
        /// For example: "110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9"
        /// 
        /// The value is case insensitive.
        /// </summary>
		string CampaignId { get; }

		/// <summary>
        /// Returns channel's GUID.
        /// For example: "110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9"
        /// 
        /// The value is case insensitive.
        /// </summary>
		string ChannelId { get; }

		/// <summary>
        ///     Gets or sets the total engagement value collected in this interaction
        /// </summary>
        /// <value>
        ///     The engagement value.
        /// </value>
		int EngagementValue { get; }

		/// <summary>
        ///     Gets or sets the point in time where this interaction started.
        /// </summary>
        /// <value>
        ///     The start date time.
        /// </value>
		DateTime StartDateTime { get; }

		/// <summary>
        ///     Gets or sets the point in time where this interaction ended. For the web channel this is when the session ended.
        ///     Different logic may apply to different channels.
        /// </summary>
        /// <value>
        ///     The point in time the interaction ended.
        /// </value>
		DateTime EndDateTime { get; }

        /// <summary>
        ///     The <see cref="Event" />s that occured in this interaction, including goals and outcomes.
        /// </summary>
        /// <value>
        ///     A collection of events.
        /// </value>
		Collection<IUTEvent> Events { get; }

		/// <summary>
        ///     Gets or sets the initiator of this interaction.
        /// </summary>
        /// <value>
        ///     The initiator.
        /// </value>
        // public enum InteractionInitiator
		InteractionInitiator Initiator { get; }

		/// <summary>
        ///     Gets or sets a string that describes the device, browser or similar used for the interaction.
        /// </summary>
        /// <value>
        ///     The user agent.
        /// </value>
        string UserAgent { get; }

		/// <summary>
        ///     Gets or sets the ID of the venue, if any, where this interaction occured.
        /// </summary>
        /// <value>
        ///     The venue ID.
        /// </value>
        string VenueId { get; }



		//@IGK aka  public IEntityReference<Contact> LastKnownContact { get; set; } looks like not available for me!!?
        //public IEntityReference<DeviceProfile> DeviceProfile { get; set; }

		//@IGK not available for me
		//IEntityReference<Contact> Contact { get; internal set; }

		//@IGK not available for me
		//EntityType EntityType
    }

	public enum InteractionInitiator
    {
        /// <summary>
        ///     The contact initiated the interaction
        /// </summary>
        Contact = 0,

        /// <summary>
        ///     The brand, or something acting on behalf of the brand, inititated the interaction
        /// </summary>
        Brand = 1,

        /// <summary>
        ///     The initiator of the interaction is unknown.
        /// </summary>
        Unknown = 2
    }
}
