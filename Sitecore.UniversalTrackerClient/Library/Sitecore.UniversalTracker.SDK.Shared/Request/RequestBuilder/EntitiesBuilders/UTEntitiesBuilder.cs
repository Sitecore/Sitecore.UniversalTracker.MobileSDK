
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

        public static IEventRequestParametersBuilder<IUTEvent> Event()
        {
            return new EventBuilder();
        }

        public static IEventRequestParametersBuilder<IUTGoal> Goal()
        {
            return new GoalBuilder();
        }

        public static IOutcomeRequestParametersBuilder<IUTOutcome> Outcome()
        {
            return new OutcomeBuilder();
        }

        public static IPageViewRequestParametersBuilder<IUTPageView> PageView()
        {
            return new PageViewBuilder();
        }

        public static IEventRequestParametersBuilder<IUTSearch> Search(string keywords)
        {
            return new SearchBuilder(keywords);
        }
    }
}
