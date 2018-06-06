namespace Sitecore.UniversalTrackerClient
{
    public interface IUTGrammar
    {
        string AnalyticsEndpoint { get; }

        string LatitudeFieldName { get; }
        string LongitudeFieldName { get; }

        string ErrorFieldName { get; }
        string ErrorDescriptionFieldName { get; }

        string AppLaunchedFieldName { get; }
        string AppFinishedFieldName { get; }


    }
}