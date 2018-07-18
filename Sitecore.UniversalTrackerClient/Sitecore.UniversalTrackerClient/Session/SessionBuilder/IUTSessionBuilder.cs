using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Session.SessionBuilder
{
    public interface IUTSessionBuilder
    {
        ISitecoreUTSession BuildSession();

        IUTSessionBuilder TokenValue(string tokenValue);

        IUTSessionBuilder DefaultInteraction(IUTInteraction interaction);

    }
}