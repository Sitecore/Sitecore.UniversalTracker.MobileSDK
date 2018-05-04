using System.Threading;
using System.Threading.Tasks;

namespace Sitecore.UniversalTrackerClient.Session
{
    public interface ISitecoreUTSessionActions
    {

        Task<UTAuthResponse> AuthenticateAsync(CancellationToken cancelToken = default(CancellationToken));

        Task<UTTrackEventResponse> TrackEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken));

    }
}