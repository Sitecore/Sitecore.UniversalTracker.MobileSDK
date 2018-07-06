using System;
namespace Sitecore.UniversalTrackerClient.Entities
{
    public class UTOutcome : UTEvent, IUTOutcome
    {
        private UTOutcome()
        {
        }

        public UTOutcome(IUTEvent utEvent, string currencyCode, decimal monetaryValue) 
            : base
        (
                utEvent.Timestamp,
                utEvent.CustomValues,
                utEvent.DefinitionId,
                utEvent.ItemId,
                utEvent.EngagementValue,
                utEvent.ParentEventId,
                utEvent.Text,
                utEvent.Duration
            )
        {
            this.CurrencyCode = currencyCode;
            this.MonetaryValue = monetaryValue;
        }

        public string CurrencyCode
        {
            get;
            private set;
        }

        public decimal MonetaryValue
        {
            get;
            private set;
        }

        public IUTOutcome DeepCopyUTOutcome()
        {
            var utEvent = new UTEvent(
                this.Timestamp,
                this.CustomValues,
                this.DefinitionId,
                this.ItemId,
                this.EngagementValue,
                this.ParentEventId,
                this.Text,
                this.Duration
            );


            var utOutcome = new UTOutcome(
                utEvent,
                this.CurrencyCode,
                this.MonetaryValue
            );

            return utOutcome;
        }
    }
}
