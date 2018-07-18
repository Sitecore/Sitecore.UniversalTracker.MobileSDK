
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;


    public class UTEntitiesBuilder
    {
        private UTEntitiesBuilder()
        {
        }

        public static IInteractionParametersBuilder<IUTInteraction> Interaction()
        {
            return new InteractionBuilder();
        }

    }
}
