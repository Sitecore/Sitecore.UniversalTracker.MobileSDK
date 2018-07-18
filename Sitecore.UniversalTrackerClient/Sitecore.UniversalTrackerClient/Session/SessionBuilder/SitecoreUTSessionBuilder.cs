namespace Sitecore.UniversalTrackerClient.Session.SessionBuilder
{
    using System;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Session.Config;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;

    public class SitecoreUTSessionBuilder : IUTSessionBuilder
    {
        private string instanceUrl;
        private string uTTokenValue;
        private IUTInteraction defaultInteraction;

        #region Constructor
        private SitecoreUTSessionBuilder()
        {
        }
        
        public static SitecoreUTSessionBuilder SessionWithHost(string instanceUrl)
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

        public IUTSessionBuilder DefaultInteraction(IUTInteraction interaction)
        {
            if (interaction == null)
            {
                return this;
            }

            BaseValidator.CheckForTwiceSetAndThrow(this.defaultInteraction, this.GetType().Name + ".interactionRequest");

            this.defaultInteraction = interaction;

            return this;
        }


        public ISitecoreUTSession BuildSession()
        {
            var config = new UTSessionConfig(this.instanceUrl);
            var session = new UTSession(config, this.instanceUrl, this.defaultInteraction);

            return session;
        }

    }
}
