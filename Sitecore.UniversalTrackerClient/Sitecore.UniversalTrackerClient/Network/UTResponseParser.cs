using System.Threading;
using Sitecore.UniversalTrackerClient.Response;

namespace Sitecore.UniversalTrackerClient.TaskFlow
{

    public class UTResponseParser
    {
        private UTResponseParser()
        {
        }

		public static UTResponse ParseEvent(string responseString, int statusCode, CancellationToken cancelToken)
        {

#warning @igk not implemented!!!
            return new UTResponse(statusCode, responseString);
        }

    }
}