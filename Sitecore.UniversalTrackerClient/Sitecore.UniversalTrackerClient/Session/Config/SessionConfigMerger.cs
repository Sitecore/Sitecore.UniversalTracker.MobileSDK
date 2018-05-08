namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using System;
	using Sitecore.UniversalTrackerClient.Session.Config;

	public class SessionConfigMerger
    {
		public SessionConfigMerger(IUTSessionConfig defaultSessionConfig)
        {
            this.defaultSessionConfig = defaultSessionConfig;

            this.Validate();
        }

		public IUTSessionConfig FillSessionConfigGaps(IUTSessionConfig userConfig)
        {
            if (null == userConfig)
            {
                return this.defaultSessionConfig;
            }

            var result = new SessionConfigPOD();
            result.InstanceUrl = userConfig.InstanceUrl ?? this.defaultSessionConfig.InstanceUrl;

            return result;
        }

		private void Validate()
        {
            if (null == this.defaultSessionConfig)
            {
				throw new ArgumentNullException(ConfigNullExeptionText);
            }
            else if (null == this.defaultSessionConfig.InstanceUrl)
            {
				throw new ArgumentNullException(UrlNullExeptionText);
            }
        }

        private readonly IUTSessionConfig defaultSessionConfig;

		private const string ConfigNullExeptionText = "SessionConfigMerger.defaultSessionConfig cannot be null";
        private const string UrlNullExeptionText = "SessionConfigMerger.defaultSessionConfig.InstanceUrl cannot be null";

    }
}