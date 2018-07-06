namespace Sitecore.UniversalTrackerClient.TaskFlow
{
	using System;
	using System.Diagnostics;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;
	using Sitecore.UniversalTrackerClient.Response;
	using Sitecore.UniversalTrackerClient.UserRequest;

	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;

    internal abstract class AbstractTrackBaseEventTask<T> : IRestApiCallTasks<T, HttpRequestMessage, string, UTEventResponse>
        where T : class, IBaseRequest

    {
        private readonly TrackEventUrlBuilder<T> trackEventUrlBuilder;
        private readonly HttpClient httpClient;

        public AbstractTrackBaseEventTask(
            TrackEventUrlBuilder<T> trackEventUrlBuilder,
          HttpClient httpClient)
        {
            this.trackEventUrlBuilder = trackEventUrlBuilder;
            this.httpClient = httpClient;

            this.Validate();
        }

        public abstract StringContent BodyContentForRequest(T request);

        public HttpRequestMessage BuildRequestUrlForRequestAsync(T request, CancellationToken cancelToken)
        {
            var url = this.trackEventUrlBuilder.GetUrlForRequest(request);

            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Post, url);

            StringContent bodycontent = this.BodyContentForRequest(request);

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

		public async Task<UTEventResponse> ParseResponseDataAsync(string httpData, CancellationToken cancelToken)
        {
			Func<UTEventResponse> syncParseResponse = () =>
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

            if (null == this.trackEventUrlBuilder)
            {
                throw new ArgumentNullException("TrackEventTask.TrackEventBuilder cannot be null");
            }
        }

        private int statusCode = 0;

    }
}