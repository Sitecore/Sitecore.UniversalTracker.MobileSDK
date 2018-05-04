using Sitecore.UniversalTrackerClient.Session;

namespace Sitecore.UniversalTrackerClient
{
    internal class UserRequestMerger
    {
        private IUTSessionConfig sessionConfig;

        public UserRequestMerger(IUTSessionConfig sessionConfig)
        {
            this.sessionConfig = sessionConfig;
        }

        public IReadItemsByIdRequest FillReadItemByIdGaps(IReadItemsByIdRequest userRequest)
        {
            IItemSource mergedSource = this.ItemSourceMerger.FillItemSourceGaps(userRequest.ItemSource);
            ISessionConfig mergedSessionConfig = this.SessionConfigMerger.FillSessionConfigGaps(userRequest.SessionSettings);

            return new ReadItemsByIdParameters(
              mergedSessionConfig,
              mergedSource,
              userRequest.QueryParameters,
              userRequest.IncludeStandardTemplateFields,
              userRequest.ItemId);
        }
    }
}