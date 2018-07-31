namespace Sitecore.UniversalTrackerClient
{
    using System;

    public class UTGrammar : IUTGrammar
    {

        public static UTGrammar UTV1Grammar()
        {
#warning not implemented!!!
            UTGrammar result = new UTGrammar();

            result.AnalyticsInteractionEndpoint = "interaction";
            result.AnalyticsEventEndpoint = "event";

            result.LatitudeFieldName = "utlatitude";
            result.LongitudeFieldName = "utlongitude";
			
            result.ErrorFieldName = "uterror";
            result.ErrorDescriptionFieldName = "uterrordescription";
			
            result.AppLaunchedFieldName = "utapplaunched";
            result.AppFinishedFieldName = "utappfinished";

            result.PageOpenedFieldName = "utpageopened";
            result.PageClosedFieldName = "utpageclosed";
            result.PageIdFieldName = "utpageid";


            result.DeviceNameFieldName = "utdevicename";
            result.OperatingSystemNameFieldName = "utoperatingsystemname";
            result.OperatingSystemVersionFieldName = "utoperatingsystemversion";
            result.DeviceModelFieldName = "utdevicemodel";
            result.DeviceLocalizedModelFieldName = "utdevicelocalizedmodel";
            result.BatteryLevelFieldName = "utbatterylevel";

            result.DeviceIdentifierKeyValue = "utdeviceidentifier";

            return result;
        }

        private UTGrammar()
        {
        }

        public string AnalyticsInteractionEndpoint  { get; private set; }
        public string AnalyticsEventEndpoint        { get; private set; }

        public string LatitudeFieldName         { get; private set; }
        public string LongitudeFieldName        { get; private set; }

        public string ErrorFieldName            { get; private set; }
        public string ErrorDescriptionFieldName { get; private set; }

        public string AppLaunchedFieldName      { get; private set; }
        public string AppFinishedFieldName      { get; private set; }

        public string PageOpenedFieldName   { get; private set; }
        public string PageClosedFieldName   { get; private set; }
        public string PageIdFieldName       { get; private set; }

        public string DeviceNameFieldName             { get; private set; }
        public string OperatingSystemNameFieldName    { get; private set; }
        public string OperatingSystemVersionFieldName { get; private set; }
        public string DeviceModelFieldName            { get; private set; }
        public string DeviceLocalizedModelFieldName   { get; private set; }
        public string BatteryLevelFieldName           { get; private set; }

        public string DeviceIdentifierKeyValue { get; private set; }
    }
}
