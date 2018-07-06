namespace Sitecore.UniversalTrackerClient.Request.UrlBuilders
{
	using System;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public class TrackEventUrlBuilder<T> : AbstractTrackUrlBuilder<T>
        where T : class, IBaseRequest
    {
        public TrackEventUrlBuilder(IUTGrammar utGrammar) :
		base(utGrammar)
        {
        }

        protected override string GetSpecificPartForRequest(T request)
        {
            return "";
            throw new NotImplementedException();
        }

        protected override void ValidateSpecificRequest(T request)
        {
            return;
            throw new NotImplementedException();
        }
    }
}
