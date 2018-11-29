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
        private string deviceIdentifierValue;
        private IUTInteraction defaultInteractionValue;

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

            BaseValidator.CheckForTwiceSetAndThrow(this.defaultInteractionValue, this.GetType().Name + ".defaultInteraction");

            this.defaultInteractionValue = interaction;

            return this;
        }

        public IUTSessionBuilder DeviceIdentifier(string deviceIdentifier)
        {
            if (string.IsNullOrEmpty(deviceIdentifier))
            {
                return this;
            }

            BaseValidator.CheckForTwiceSetAndThrow(this.deviceIdentifierValue, this.GetType().Name + ".deviceIdentifier");
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(deviceIdentifier, this.GetType().Name + ".deviceIdentifier");

            this.deviceIdentifierValue = deviceIdentifier;
            return this;
        }


        public ISitecoreUTSession BuildSession()
        {
            var config = new UTSessionConfig(this.instanceUrl);
            var session = new UTSession(config, this.defaultInteractionValue, this.deviceIdentifierValue, this.uTTokenValue);

            return session;
        }

    }
}
