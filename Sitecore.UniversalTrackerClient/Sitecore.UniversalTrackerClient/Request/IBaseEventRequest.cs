
namespace Sitecore.UniversalTrackerClient.Session
{
	using Sitecore.UniversalTrackerClient.Session.Config;

    public interface IBaseEventRequest
    {
		IBaseEventRequest DeepCopyBaseEventRequest();
        
        System.Collections.Generic.IDictionary<string, string> FieldsRawValuesByName { get; }

		IUTSessionConfig SessionConfig { get; }
    }
}