
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Helpers;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using System;

    public class DeviceInformationEventRequestBuilder : EventForDefenitionIdRequestBuilder<ITrackPageOpenedEventRequest>

    {
        public DeviceInformationEventRequestBuilder(string deviceName) : base()
        {
            base.AddCustomValues(UTGrammar.UTV1Grammar().DeviceNameFieldName, deviceName);
        }

      
        public DeviceInformationEventRequestBuilder OperatingSystemName(string osName)
        {
            base.AddCustomValues(UTGrammar.UTV1Grammar().OperatingSystemNameFieldName, osName);

            return this;
        }

        public DeviceInformationEventRequestBuilder DeviceModel(string model, string localizedModel)
        {
            base.AddCustomValues(UTGrammar.UTV1Grammar().DeviceModelFieldName, model);

            if (localizedModel != null)
            {
                base.AddCustomValues(UTGrammar.UTV1Grammar().DeviceLocalizedModelFieldName, localizedModel);
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
            base.AddCustomValues(UTGrammar.UTV1Grammar().BatteryLevelFieldName, batteryLevel.ToString());

            return this;
        }

        public override ITrackPageOpenedEventRequest Build()
        {
            return base.Build();
        }
    }
}

