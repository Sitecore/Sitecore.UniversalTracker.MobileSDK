namespace Sitecore.UniversalTrackerClient.Request.UrlBuilders
{
	using System;
    using Sitecore.UniversalTrackerClient.UserRequest;

    public class TrackEventUrlBuilder<T> : AbstractTrackUrlBuilder<T>
		where T : class, ITrackEventRequest
    {
        public TrackEventUrlBuilder(IUTUrlParameters utGrammar) :
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
