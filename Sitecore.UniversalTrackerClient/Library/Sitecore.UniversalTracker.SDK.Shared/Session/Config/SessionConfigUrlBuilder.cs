namespace Sitecore.UniversalTrackerClient.Session.Config
{
    using System;
    using Sitecore.UniversalTrackerClient;
	using Sitecore.UniversalTrackerClient.Validators;

	public class SessionConfigUrlBuilder
    {
        public SessionConfigUrlBuilder(IUTGrammar utGrammar)
        {
			this.utGrammar = utGrammar;

            this.Validate();
        }

        public virtual string BuildUrlString(IUTSessionConfig config)
        {

			this.ValidateRequest(config);
            
			string autocompletedInstanceUrl = SessionConfigValidator.AutocompleteInstanceUrlWithHttps(config.InstanceUrl);

            return autocompletedInstanceUrl.ToLowerInvariant();
        }


		private void ValidateRequest(IUTSessionConfig config)
        {
			if (null == config)
            {
				throw new ArgumentNullException(nameof(SessionConfigUrlBuilder), " ValidateRequest() : do not pass null");
            }
        }

        private void Validate()
        {
			if (null == this.utGrammar)
            {
				throw new ArgumentNullException(nameof(SessionConfigUrlBuilder), " utGrammar cannot be null");
            }
          
        }

        private IUTGrammar utGrammar;
    }
}
