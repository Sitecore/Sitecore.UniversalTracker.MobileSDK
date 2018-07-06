namespace Sitecore.UniversalTrackerClient.Session
{
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.Response;
	using Sitecore.UniversalTrackerClient.UserRequest;

	public interface ISitecoreUTSessionActions
    {
        Task<UTAuthResponse> AuthenticateAsync(CancellationToken cancelToken = default(CancellationToken));

        Task<UTEventResponse> TrackEventAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken));

        Task<UTEventResponse> TrackLocationEventAsync(ITrackLocationEventRequest request, CancellationToken cancelToken = default(CancellationToken));

        Task<UTEventResponse> TrackErrorEventAsync(ITrackErrorEventRequest request, CancellationToken cancelToken = default(CancellationToken));

        Task<UTEventResponse> TrackInteractionAsync(ITrackInteractionRequest request, CancellationToken cancelToken = default(CancellationToken));
    }
}