namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;

    public interface ITrackEventRequest : IBaseRequest
    {
#warning not implemented!!!

		IUTEvent Event { get; }

		ITrackEventRequest DeepCopyTrackEventRequest();
    }
}