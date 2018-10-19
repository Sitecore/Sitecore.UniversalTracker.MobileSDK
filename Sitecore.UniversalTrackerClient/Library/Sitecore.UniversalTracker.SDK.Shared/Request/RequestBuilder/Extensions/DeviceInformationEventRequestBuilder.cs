
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.UserRequest;
    using System;
    using System.Collections.Generic;

    public class DeviceInformationEventRequestBuilder : EventForDefenitionIdRequestBuilder<ITrackPageOpenedEventRequest>

    {
        private UTGrammar grammar = UTGrammar.UTV1Grammar();

        public DeviceInformationEventRequestBuilder(string deviceName) : base()
        {
            base.AddCustomValues(grammar.DeviceNameFieldName, deviceName);
        }

        public DeviceInformationEventRequestBuilder OperatingSystem(string osName, string osVersion)
        {
            base.AddCustomValues(grammar.OperatingSystemNameFieldName, osName);
            base.AddCustomValues(grammar.OperatingSystemVersionFieldName, osVersion);

            return this;
        }

        public DeviceInformationEventRequestBuilder DeviceModel(string model, string localizedModel)
        {
            base.AddCustomValues(grammar.DeviceModelFieldName, model);

            if (localizedModel != null)
            {
                base.AddCustomValues(grammar.DeviceLocalizedModelFieldName, localizedModel);
            }

            return this;
        }

        /// <summary>
        /// The battery charge level for the device.
        /// </summary>
        /// <param name="batteryLevel">Battery level ranges from 0.0 (fully discharged) to 1.0 (100% charged).</param>
        /// <returns>
        /// this
        /// </returns>
        public DeviceInformationEventRequestBuilder BatteryLevel(float batteryLevel)
        {
            base.AddCustomValues(grammar.BatteryLevelFieldName, batteryLevel.ToString());

            return this;
        }

        public override ITrackPageOpenedEventRequest Build()
        {
            return base.Build();
        }

        #region fluent support

        public new DeviceInformationEventRequestBuilder AddCustomValues(IDictionary<string, string> customValues)
        {
            base.AddCustomValues(customValues);

            return this;
        }

        public new DeviceInformationEventRequestBuilder DeviceIdentifier(string deviceIdentifier)
        {
            base.DeviceIdentifier(deviceIdentifier);

            return this;
        }

        public new DeviceInformationEventRequestBuilder AddCustomValues(string customFieldName, string customFieldValue)
        {
            base.AddCustomValues(customFieldName, customFieldValue);

            return this;
        }


        public new DeviceInformationEventRequestBuilder DefinitionId(string definitionId)
        {
            base.DefinitionId(definitionId);

            return this;
        }


        public new DeviceInformationEventRequestBuilder ItemId(string itemId)
        {
            base.ItemId(itemId);

            return this;
        }

        public new DeviceInformationEventRequestBuilder EngagementValue(int engagementValue)
        {
            base.EngagementValue(engagementValue);

            return this;
        }

        public new DeviceInformationEventRequestBuilder ParentEventId(string parentEventId)
        {
            base.ParentEventId(parentEventId);

            return this;
        }

        public new DeviceInformationEventRequestBuilder Text(string text)
        {
            base.Text(text);

            return this;
        }

        public new DeviceInformationEventRequestBuilder Timestamp(DateTime timestamp)
        {
            base.Timestamp(timestamp);

            return this;
        }

        public new DeviceInformationEventRequestBuilder Duration(TimeSpan duration)
        {
            base.Duration(duration);

            return this;
        }

        #endregion fluent support
    }
}

