
namespace Sitecore.UniversalTrackerClient.Entities
{
    using System;
    using System.Collections.Generic;

    public interface IUTEvent
    {

        IUTEvent DeepCopyUTEvent();


		/// <summary>
        ///     A dictionary of string for event custom data for legacy support.
        /// </summary>
        /// <value>
        ///     The custom values.
        /// </value>
        Dictionary<string, string> CustomValues { get; }

        /// <summary>
        ///     Gets or sets the definition ID for the type of this event.
        /// </summary>
        /// <value>
        ///     The definition identifier.
        /// </value>
        string DefinitionId { get;}


        /// <summary>
        /// Gets or sets a Sitecore item ID related to the event if any. Otherwise use <see cref="Guid.Empty"/>.
        /// </summary>
        /// <value>
        /// The Sitecore item ID.
        /// </value>
        string ItemId { get;}

        /// <summary>
        ///     Gets or sets the engagement value generated from this event, at the point in time it occurred.
        /// </summary>
        /// <value>
        ///     The engagement value.
        /// </value>
        int? EngagementValue { get; }

        /// <summary>
        ///     Gets or sets the ID of another event in the interaction that defines the context for this event. For example, a
        ///     click on a link may happen in the context of a page view event.
        /// </summary>
        /// <value>
        ///     The ID of the event.
        /// </value>
        string ParentEventId { get; }


        /// <summary>
        ///     Gets or sets the text for this event for legacy support.
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        string Text { get; }

        /// <summary>
        ///     Gets or sets the point in time where the event occured.
        /// </summary>
        /// <value>
        ///     The timestamp.
        /// </value>
        DateTime? Timestamp { get; }


        /// <summary>
        /// Gets or sets the duration of this event.
        /// How duration is measured is specific to the nature of the event.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        TimeSpan? Duration { get; }

        string type { get; }

        string TrackingInteractionId { get; }

        void ApplyActiveInteractionWith(string interactionId);
    }


}