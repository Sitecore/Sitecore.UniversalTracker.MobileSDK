namespace Sitecore.UniversalTrackerClient.Request.UrlBuilders
{
	using System;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public class CompleteInteractionUrlBuilder<T> : AbstractTrackUrlBuilder<T>
		where T : class, ICompleteInteractionRequest
    {
        public CompleteInteractionUrlBuilder(IUTGrammar utGrammar) :
		base(utGrammar)
        {
        }

        protected override string GetEndpointForRequest()
        {
            return this.utGrammar.AnalyticsCompleteInteractionEndpoint;
        }


        protected override string GetSpecificPartForRequest(T request)
        {
            return ""; 
        }

        protected override void ValidateSpecificRequest(T request)
        {
            return;
        }
    }
}
