namespace Sitecore.UniversalTrackerClient
{
    public interface IUTGrammar
    {
        string AnalyticsInteractionEndpoint { get; }
        string AnalyticsEventEndpoint { get; }

        string LatitudeFieldName { get; }
        string LongitudeFieldName { get; }

        string ErrorFieldName { get; }
        string ErrorDescriptionFieldName { get; }

        string AppLaunchedFieldName { get; }
        string AppFinishedFieldName { get; }


    }
}