namespace Sitecore.UniversalTrackerClient.Response
{
    using System.Threading;

    public class UTTrackResponseParser
    {
        private UTTrackResponseParser()
        {
        }

        public static UTEventResponse Parse(string responseString, CancellationToken cancelToken)
        {
            return UTTrackResponseParser.Parse(responseString, 0, cancelToken);
        }

        public static UTEventResponse Parse(string responseString, int responseCode, CancellationToken cancelToken)
        {
#warning not implemented!!!
            return new UTEventResponse(responseCode);
        }

    }
}