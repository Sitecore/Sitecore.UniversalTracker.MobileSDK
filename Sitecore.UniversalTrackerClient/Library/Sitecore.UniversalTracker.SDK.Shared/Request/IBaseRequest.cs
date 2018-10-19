
namespace Sitecore.UniversalTrackerClient.UserRequest
{
	using Sitecore.UniversalTrackerClient.Session.Config;

    public interface IBaseRequest
    {
		IBaseRequest DeepCopyBaseRequest();
        
		IUTSessionConfig SessionConfig { get; }

    }
}