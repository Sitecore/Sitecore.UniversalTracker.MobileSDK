using System.Threading;
using Sitecore.UniversalTrackerClient.Response;

namespace Sitecore.UniversalTrackerClient.TaskFlow
{

	public class UTTrackEventResponseParser
    {
		private UTTrackEventResponseParser()
        {
        }

		public static UTEventResponse Parse(string responseString, int statusCode, CancellationToken cancelToken)
        {

#warning @igk not implemented!!!
			return new UTEventResponse(statusCode);
        }

    }
}