namespace Sitecore.UniversalTrackerClient.Session.SessionBuilder
{
    using System;
    using Sitecore.UniversalTrackerClient.Session.Config;
    using Sitecore.UniversalTrackerClient.Validators;

    public class SitecoreUTSessionBuilder : IUTSessionBuilder
    {
        private string instanceUrl;
        private string uTTokenValue;

        #region Constructor
        private SitecoreUTSessionBuilder()
        {
        }

        public static SitecoreUTSessionBuilder SessionBuilderWithHost(string instanceUrl)
        {
            BaseValidator.CheckForNullAndEmptyOrThrow(instanceUrl, typeof(SitecoreUTSessionBuilder).Name + ".InstanceUrl");

            var result = new SitecoreUTSessionBuilder
            {
                instanceUrl = instanceUrl
            };

            return result;
        }
        #endregion Constructor

       
        public IUTSessionBuilder TokenValue(string tokenValue)
        {
            if (string.IsNullOrEmpty(tokenValue))
            {
                return this;
            }

            BaseValidator.CheckForTwiceSetAndThrow(this.uTTokenValue, this.GetType().Name + ".tokenValue");
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(tokenValue, this.GetType().Name + ".tokenValue");

            this.uTTokenValue = tokenValue;
            return this;
        }

        public ISitecoreUTSession BuildSession()
        {
            var config = new UTSessionConfig(this.instanceUrl);
            var session = new UTSession(config, this.instanceUrl);

            return session;
        }

    }
}
