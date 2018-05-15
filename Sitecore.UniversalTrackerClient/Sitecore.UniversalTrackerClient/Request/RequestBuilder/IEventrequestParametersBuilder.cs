namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
	using System;
	using System.Collections.Generic;

	public interface IEventrequestParametersBuilder<T> : IBaseRequestParametersBuilder<T>
     where T : class
    {

		IEventrequestParametersBuilder<T> AddCustomValuesToSet(IDictionary<string, string> customValuesByName);

        /// <summary>
        /// Adds fields that will be updated in item.
        /// </summary>
        /// <param name="fieldName">Field name.</param>
        /// <param name="fieldValue">Field raw value.</param>
        /// <returns>
        /// this
        /// </returns>
		IEventrequestParametersBuilder<T> AddCustomValuesToSet(string fieldName, string fieldValue);

		IEventrequestParametersBuilder<T> DefinitionId(string definitionId);

		IEventrequestParametersBuilder<T> ItemId(string itemId);

		IEventrequestParametersBuilder<T> EngagementValue(int engagementValue);

		IEventrequestParametersBuilder<T> ParentEventId(string parentEventId);

		IEventrequestParametersBuilder<T> Text(string text);

		IEventrequestParametersBuilder<T> Timestamp(DateTime timestamp);

		IEventrequestParametersBuilder<T> Duration(TimeSpan duration);

    }
}
