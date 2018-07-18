namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;


	public interface ITrackInteractionRequest : IBaseRequest
    {

		IUTInteraction Interaction { get; }

		ITrackInteractionRequest DeepCopyTrackInteractionRequest();
    }
}
