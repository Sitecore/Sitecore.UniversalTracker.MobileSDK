namespace Sitecore.UniversalTrackerClient.Request.UrlBuilders
{
	using System;
    using Sitecore.UniversalTrackerClient.Syntax;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Session.Config;

	public abstract class AbstractTrackUrlBuilder<TRequest>
    where TRequest : IBaseRequest
    {
        public AbstractTrackUrlBuilder(IUTGrammar utGrammar)
        {
			this.UTGrammar = utGrammar;

            this.Validate();
        }

        #region Entry Point
        public virtual string GetUrlForRequest(TRequest request)
        {
            this.ValidateRequest(request);

            string hostUrl = this.GetHostUrlForRequest(request);
            string baseUrl = this.GetCommonPartForRequest(request).ToLowerInvariant();
            string specificParameters = this.GetSpecificPartForRequest(request);

            string allParameters = baseUrl;

            if (!string.IsNullOrEmpty(specificParameters))
            {
                allParameters =
                  allParameters +
                  RestGrammar.FieldSeparator + specificParameters;
            }

			bool shouldTruncateBaseUrl = (!string.IsNullOrEmpty(allParameters) && allParameters.StartsWith(RestGrammar.FieldSeparator, StringComparison.CurrentCulture));
            while (shouldTruncateBaseUrl)
            {
                allParameters = allParameters.Substring(1);
				shouldTruncateBaseUrl = (!string.IsNullOrEmpty(allParameters) && allParameters.StartsWith(RestGrammar.FieldSeparator, StringComparison.CurrentCulture));
            }


            string result = hostUrl;

            if (!string.IsNullOrEmpty(allParameters))
            {
                result =
                  result +
					RestGrammar.HostAndArgsSeparator + allParameters;
            }

            return result;
        }

        protected virtual void ValidateRequest(TRequest request)
        {
            this.ValidateCommonRequest(request);
            this.ValidateSpecificRequest(request);
        }
        #endregion Entry Point

        #region Common Logic
        protected virtual string GetHostUrlForRequest(TRequest request)
        {
			SessionConfigUrlBuilder sessionBuilder = new SessionConfigUrlBuilder(this.UTGrammar);
			string hostUrl = sessionBuilder.BuildUrlString(request.SessionConfig);
            hostUrl = hostUrl + RestGrammar.PathComponentSeparator + this.UTGrammar.AnalyticsEndpoint;

            return hostUrl;
        }

        private string GetCommonPartForRequest(TRequest request)
        {
#warning @IGK not implemented!!!
			return "";
        }

        private void ValidateCommonRequest(TRequest request)
        {
            if (null == request)
            {
				throw new ArgumentNullException(nameof(request), " AbstractTrackUrlBuilder : request cannot be null");
            }
			else if (null == request.SessionConfig)
            {
				throw new ArgumentNullException(nameof(request.SessionConfig), "AbstractTrackUrlBuilder : request.SessionSettings cannot be null");
            }
            else if (null == request.SessionConfig.InstanceUrl)
            {
				throw new ArgumentNullException(nameof(request.SessionConfig.InstanceUrl), "AbstractTrackUrlBuilder : request.SessionSettings.InstanceUrl cannot be null");
            }
        }
      
        private void Validate()
        {
			if (null == this.UTGrammar)
            {
                throw new ArgumentNullException("[AbstractTrackUrlBuilder] urlGrammar cannot be null");
            }
           
        }
        #endregion Common Logic

        #region Abstract Methods
        protected abstract string GetSpecificPartForRequest(TRequest request);

        protected abstract void ValidateSpecificRequest(TRequest request);
        #endregion Abstract Methods

        #region instance variables
        protected IUTGrammar UTGrammar;
        #endregion instance variables
    }
}
