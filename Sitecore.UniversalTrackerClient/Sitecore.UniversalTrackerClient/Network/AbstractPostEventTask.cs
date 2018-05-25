namespace Sitecore.UniversalTrackerClient.EventTasks
{
    using System;
    using System.Net.Http;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Sitecore.UniversalTrackerClient.TaskFlow;
	using Sitecore.UniversalTrackerClient.Response;

	internal abstract class AbstractPostEventTask<TRequest, TResponse> : IRestApiCallTasks<TRequest, HttpRequestMessage, string, TResponse>
      where TRequest : class
      where TResponse : class
    {

        private AbstractPostEventTask()
        {
        }

        public AbstractPostEventTask(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            this.Validate();
        }

        #region  IRestApiCallTasks

        public virtual HttpRequestMessage BuildRequestUrlForRequestAsync(TRequest request, CancellationToken cancelToken)
        {
            string url = this.UrlToGetItemWithRequest(request);
            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Get, url);

            return result;
        }

        public virtual async Task<string> SendRequestForUrlAsync(HttpRequestMessage requestUrl, CancellationToken cancelToken)
        {
#warning @igk debug request output, remove later
            Debug.WriteLine("REQUEST: " + requestUrl);
            HttpResponseMessage httpResponse = await this.httpClient.SendAsync(requestUrl, cancelToken);
            this.statusCode = (int)httpResponse.StatusCode;
            return await httpResponse.Content.ReadAsStringAsync();
        }

        public virtual async Task<TResponse> ParseResponseDataAsync(string data, CancellationToken cancelToken)
        {
			Func<UTEventResponse> syncParseResponse = () =>
            {
#warning @igk debug response output, remove later
                Debug.WriteLine("RESPONSE: " + data);
                return UTResponseParser.ParseEvent(data, this.statusCode, cancelToken);
            };
            return await Task.Factory.StartNew(syncParseResponse, cancelToken) as TResponse;
        }

        #endregion IRestApiCallTasks

        private void Validate()
        {
            if (null == this.httpClient)
            {
                throw new ArgumentNullException("AbstractPostEventTask.httpClient cannot be null");
            }

        }

        public int HttpResponseStatusCode()
        {
            return this.statusCode;
        }

        private int statusCode = 0;

        protected abstract string UrlToGetItemWithRequest(TRequest request);

        protected HttpClient httpClient;
    }
}




