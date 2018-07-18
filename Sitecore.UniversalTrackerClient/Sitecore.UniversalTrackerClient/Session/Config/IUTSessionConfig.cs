namespace Sitecore.UniversalTrackerClient.Session.Config
{
    public interface IUTSessionConfig
    {
        IUTSessionConfig SessionConfigShallowCopy();

        /// <summary>
        /// Specifies URL to the Sitecore instance, must starts with "http://" or "https://" prefix.
        /// 
        /// The value is case insensitive.
        /// </summary>
        string InstanceUrl
        {
            get;
        }

        string ActiveInteractionId
        {
            get;
        }
    }
}