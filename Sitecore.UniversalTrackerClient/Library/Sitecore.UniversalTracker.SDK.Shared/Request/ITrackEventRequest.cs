namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;

    public interface ITrackEventRequest : IBaseRequest
    {

		IUTEvent Event { get; }

		ITrackEventRequest DeepCopyTrackEventRequest();
    }
}