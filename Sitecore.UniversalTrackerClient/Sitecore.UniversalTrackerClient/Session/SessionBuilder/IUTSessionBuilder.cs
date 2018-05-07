namespace Sitecore.UniversalTrackerClient.Session.SessionBuilder
{
    public interface IUTSessionBuilder
    {

        ISitecoreUTSession BuildSession();

        IUTSessionBuilder TokenValue(string tokenValue);
    }
}