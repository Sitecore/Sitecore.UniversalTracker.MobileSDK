namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Entities;


	public interface ICompleteInteractionRequest : IBaseRequest
    {
        string InteractionId { get; }
		ICompleteInteractionRequest DeepCopyCompleteInteractionRequest();
    }
}
