namespace Sitecore.UniversalTrackerClient.Session.Config
{
    using System;
    using System.Diagnostics;
    using Sitecore.UniversalTrackerClient.Validators;

    public class UTSessionConfig : IUTSessionConfig
    {
        public UTSessionConfig(string instanceUrl)
        {
            this.InstanceUrl = instanceUrl;

            this.Validate();
        }

        #region ICloneable
        public virtual UTSessionConfig ShallowCopy()
        {
            UTSessionConfig result = new UTSessionConfig(
              this.InstanceUrl
            );

            return result;
        }

        public virtual IUTSessionConfig SessionConfigShallowCopy()
        {
            return this.ShallowCopy();
        }
        #endregion ICloneable

        #region Properties
        public string InstanceUrl
        {
            get;
            protected set;
        }
        #endregion Properties

        #region Validation
        private void Validate()
        {
            BaseValidator.CheckForNullEmptyAndWhiteSpaceOrThrow(this.InstanceUrl, "SessionConfig.InstanceUrl is required");

            if (!SessionConfigValidator.IsValidSchemeOfInstanceUrl(this.InstanceUrl))
            {
                Debug.WriteLine("[WARNING] : SessionConfig - instance URL does not have a scheme");
            }
        }
        #endregion Validation
    }
}
