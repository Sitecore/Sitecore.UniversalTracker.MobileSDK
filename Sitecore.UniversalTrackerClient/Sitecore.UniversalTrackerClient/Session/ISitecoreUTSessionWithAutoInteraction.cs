
namespace Sitecore.UniversalTrackerClient.Session
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public interface ISitecoreUTSessionWithAutoInteraction
    {

        Task AutoInteractionAsync(ITrackEventRequest request, CancellationToken cancelToken = default(CancellationToken));

    }
}
