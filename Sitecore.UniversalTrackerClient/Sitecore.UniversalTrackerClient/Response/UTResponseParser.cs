namespace Sitecore.UniversalTrackerClient.Response
{
    using System.Diagnostics;
    using System.Threading;
    using Sitecore.UniversalTrackerClient.Validators;

    public class UTResponseParser
    {
        private UTResponseParser()
        {
        }

        public static UTResponse Parse(string responseString, CancellationToken cancelToken)
        {
            return UTResponseParser.Parse(responseString, 0, cancelToken);
        }

        public static UTResponse Parse(string responseString, int responseCode, CancellationToken cancelToken)
        {
            BaseValidator.CheckNullAndThrow(responseString, "UTTrackResponseParser.responseString");

            Debug.WriteLine("RESPONSE to PARSE RESULT: " + responseString);

#warning not implemented!!!
            return new UTResponse(responseCode, responseString);
        }

    }
}