
namespace Sitecore.UniversalTrackerClient.Session
{
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.Response;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface ISitecoreUTSessionWithAutoInteraction
    {

        Task<UTResponse> CreateInteractionAndSentEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken));

    }
}
