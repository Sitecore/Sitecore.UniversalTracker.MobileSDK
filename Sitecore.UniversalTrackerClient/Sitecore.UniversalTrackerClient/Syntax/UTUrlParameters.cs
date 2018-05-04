using System;
namespace Sitecore.UniversalTrackerClient
{
    public class UTUrlParameters : IUTUrlParameters
    {

        public static UTUrlParameters UTV1UrlParameters()
        {
#warning not implemented!!!
            UTUrlParameters result = new UTUrlParameters();
            result.AnalyticsEndpoint = "endpoint";

            return result;
        }

        private UTUrlParameters()
        {
        }

        public string AnalyticsEndpoint { get; private set; }
    }
}
