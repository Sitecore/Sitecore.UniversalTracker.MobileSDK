namespace Sitecore.UniversalTrackerClient.Request.RequestBuilder
{
    using System;

    public interface IBaseRequestParametersBuilder<T>
     where T : class
    {
        /// <summary>
        /// Builds request with specified parameters.
        /// </summary>
        /// <returns>request</returns>
        T Build();
    }
}
