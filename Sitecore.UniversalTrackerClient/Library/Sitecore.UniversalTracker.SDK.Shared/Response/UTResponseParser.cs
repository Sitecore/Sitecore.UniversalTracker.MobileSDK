namespace Sitecore.UniversalTrackerClient.Response
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading;
    using Newtonsoft.Json;
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

            string description = null;

            Collection<string> errors = null;

            bool responseContainsArray =    responseString.StartsWith("[", System.StringComparison.CurrentCultureIgnoreCase) 
                                         && responseString.EndsWith("]", System.StringComparison.CurrentCultureIgnoreCase);

            if (responseContainsArray)
            {
                errors = JsonConvert.DeserializeObject<Collection<string>>(responseString);
            }
            else
            {
                description = responseString;
            }
#warning not implemented!!!
            return new UTResponse(responseCode, description, errors);
        }

    }
}