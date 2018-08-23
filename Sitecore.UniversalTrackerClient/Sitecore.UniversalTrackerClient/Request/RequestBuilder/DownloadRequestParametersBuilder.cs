
namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.UserRequest;
    using Sitecore.UniversalTrackerClient.Validators;
    using System;
    using System.Collections.Generic;

    public class DownloadRequestParametersBuilder : AbstractEventRequestBuilder<ITrackDownloadRequest>
    {
        public DownloadRequestParametersBuilder()
        {

        }

        public override ITrackDownloadRequest Build()
        {
            Dictionary<string, string> customParameters = null;

            if (this.FieldsRawValuesByName != null)
            {
                customParameters = new Dictionary<string, string>(this.FieldsRawValuesByName);
            }

            this.EventParametersAccumulator = new UTEvent(
                    this.EventParametersAccumulator.Timestamp,
                    customParameters,
                    this.EventParametersAccumulator.DefinitionId,
                    this.EventParametersAccumulator.ItemId,
                    this.EventParametersAccumulator.EngagementValue,
                    this.EventParametersAccumulator.ParentEventId,
                    this.EventParametersAccumulator.Text,
                    this.EventParametersAccumulator.Duration,
                    this.EventParametersAccumulator.TrackingInteractionId
                );

            UTDownload utDownload = new UTDownload(this.EventParametersAccumulator);

            TrackDownloadParameters result = new TrackDownloadParameters(null, utDownload);

            return result;
        }

    }
}

