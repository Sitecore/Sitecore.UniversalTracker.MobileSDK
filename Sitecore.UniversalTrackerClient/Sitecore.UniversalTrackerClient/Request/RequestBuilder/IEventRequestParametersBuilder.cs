namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
	using System;
	using System.Collections.Generic;

	public interface IEventRequestParametersBuilder<T> : IBaseRequestParametersBuilder<T>
     where T : class
    {

		IEventRequestParametersBuilder<T> AddCustomValues(IDictionary<string, string> customValuesByName);

        /// <summary>
        /// Adds fields that will be updated in item.
        /// </summary>
        /// <param name="fieldName">Field name.</param>
        /// <param name="fieldValue">Field raw value.</param>
        /// <returns>
        /// this
        /// </returns>
		IEventRequestParametersBuilder<T> AddCustomValues(string fieldName, string fieldValue);

		IEventRequestParametersBuilder<T> DefinitionId(string definitionId);

		IEventRequestParametersBuilder<T> ItemId(string itemId);

		IEventRequestParametersBuilder<T> EngagementValue(int engagementValue);

		IEventRequestParametersBuilder<T> ParentEventId(string parentEventId);

		IEventRequestParametersBuilder<T> Text(string text);

		IEventRequestParametersBuilder<T> Timestamp(DateTime timestamp);

		IEventRequestParametersBuilder<T> Duration(TimeSpan duration);

    }
}
