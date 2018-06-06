namespace Sitecore.UniversalTrackerClient
{
    using System;

    public class UTGrammar : IUTGrammar
    {

        public static UTGrammar UTV1Grammar()
        {
#warning not implemented!!!
            UTGrammar result = new UTGrammar();
            result.AnalyticsEndpoint = "endpoint";

            result.LatitudeFieldName = "utlatitude";
            result.LongitudeFieldName = "utlongitude";
			
            result.ErrorFieldName = "uterror";
            result.ErrorDescriptionFieldName = "uterrordescription";
			
            result.AppLaunchedFieldName = "utapplaunched";
            result.AppFinishedFieldName = "utappfinished";

            return result;
        }

        private UTGrammar()
        {
        }

        public string AnalyticsEndpoint         { get; private set; }

        public string LatitudeFieldName         { get; private set; }
        public string LongitudeFieldName        { get; private set; }

        public string ErrorFieldName            { get; private set; }
        public string ErrorDescriptionFieldName { get; private set; }

        public string AppLaunchedFieldName      { get; private set; }
        public string AppFinishedFieldName      { get; private set; }
    }
}
