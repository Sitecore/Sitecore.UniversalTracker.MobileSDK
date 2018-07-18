namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System;
    using System.Text;
	using System.Diagnostics;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;
	using Sitecore.UniversalTrackerClient.Response;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;

    internal abstract class AbstractTrackBaseEventTask<T> : IRestApiCallTasks<T, HttpRequestMessage, string, UTResponse>
        where T : class, IBaseRequest

    {
        private readonly AbstractTrackUrlBuilder<T> trackUrlBuilder;
        private readonly HttpClient httpClient;

        public AbstractTrackBaseEventTask(
            AbstractTrackUrlBuilder<T> trackEventUrlBuilder,
          HttpClient httpClient)
        {
            this.trackUrlBuilder = trackEventUrlBuilder;
            this.httpClient = httpClient;

            this.Validate();
        }

        public abstract string RequestContentInJSON(T request);

        public HttpRequestMessage BuildRequestUrlForRequestAsync(T request, CancellationToken cancelToken)
        {
            var url = this.trackUrlBuilder.GetUrlForRequest(request);

            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Put, url);

            string serializedContent = this.RequestContentInJSON(request);

            StringContent bodycontent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            result.Content = bodycontent;

            return result;

        }

        public async Task<string> SendRequestForUrlAsync(HttpRequestMessage request, CancellationToken cancelToken)
        {
            //TODO: @igk debug request output, remove later
            Debug.WriteLine("REQUEST: " + request);

            var result = await this.httpClient.SendAsync(request, cancelToken);

            this.statusCode = (int)result.StatusCode;

            return await result.Content.ReadAsStringAsync();
        }

		public async Task<UTResponse> ParseResponseDataAsync(string httpData, CancellationToken cancelToken)
        {
			Func<UTResponse> syncParseResponse = () =>
            {
                //TODO: @igk debug response output, remove later
                Debug.WriteLine("RESPONSE: " + httpData);

				return UTResponseParser.ParseEvent(httpData, this.statusCode, cancelToken);
            };
            return await Task.Factory.StartNew(syncParseResponse, cancelToken);
        }

      

        private void Validate()
        {
            if (null == this.httpClient)
            {
                throw new ArgumentNullException("TrackEventTask.httpClient cannot be null");
            }

            if (null == this.trackUrlBuilder)
            {
                throw new ArgumentNullException("TrackEventTask.TrackEventBuilder cannot be null");
            }
        }

        private int statusCode = 0;

    }
}