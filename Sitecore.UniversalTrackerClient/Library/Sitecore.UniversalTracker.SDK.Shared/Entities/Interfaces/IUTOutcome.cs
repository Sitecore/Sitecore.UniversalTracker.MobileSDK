using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public interface IUTOutcome : IUTEvent
    {
        /// <summary>
        ///     ISO 4217 code for the currency of <see cref="MonetaryValue" />
        /// </summary>
        string CurrencyCode { get; }

        /// <summary>
        ///     Gets or sets the monetary value of this outcome stated in this outcome's CurrencyCode
        /// </summary>
        /// <value>
        ///     The monetary value.
        /// </value>
        decimal MonetaryValue { get; }

        IUTOutcome DeepCopyUTOutcome();
    }
}
