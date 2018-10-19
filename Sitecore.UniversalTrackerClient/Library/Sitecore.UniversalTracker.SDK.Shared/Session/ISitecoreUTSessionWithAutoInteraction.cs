
namespace Sitecore.UniversalTrackerClient.Session
{
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Response;

    public interface ISitecoreUTSessionWithAutoInteraction
    {

        Task<UTResponse> CreateInteractionAndSentEventAsync(IUTEvent utEvent, CancellationToken cancelToken = default(CancellationToken));

    }
}
