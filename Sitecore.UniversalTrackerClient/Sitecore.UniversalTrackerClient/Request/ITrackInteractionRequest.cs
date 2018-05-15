namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;


	public interface ITrackInteractionRequest : IBaseRequest
    {
#warning not implemented!!!

		IUTInteraction Interaction { get; }

		ITrackInteractionRequest DeepCopyTrackInteractionRequest();
    }
}
