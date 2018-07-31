using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.UserRequest;

namespace Sitecore.UniversalTrackerClient.Session.SessionBuilder
{
    public interface IUTSessionBuilder
    {
        ISitecoreUTSession BuildSession();

        IUTSessionBuilder TokenValue(string tokenValue);

        IUTSessionBuilder DefaultInteraction(IUTInteraction interaction);

        /// <summary>
        /// Optional device identifier, expected value - identifierForVendor for iOS, getSerial for android or similar...
        /// </summary>
        /// <returns>request</returns>
        IUTSessionBuilder DeviceIdentifier(string deviceIdentifier);
    }
}