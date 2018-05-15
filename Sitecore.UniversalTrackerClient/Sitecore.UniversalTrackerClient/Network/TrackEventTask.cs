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

	using Newtonsoft.Json.Linq;
	using Sitecore.UniversalTrackerClient.Request.UrlBuilders;
	using Newtonsoft.Json;

	internal class TrackEventTask<T> : IRestApiCallTasks<T, HttpRequestMessage, string, UTEventResponse>
		where T : class, ITrackEventRequest

    {
		private readonly TrackEventUrlBuilder<T> createEntityBuilder;
        private readonly HttpClient httpClient;

		public TrackEventTask(
			TrackEventUrlBuilder<T> createEntityBuilder,
          HttpClient httpClient)
        {
            this.createEntityBuilder = createEntityBuilder;
            this.httpClient = httpClient;

            this.Validate();
        }

        public HttpRequestMessage BuildRequestUrlForRequestAsync(T request, CancellationToken cancelToken)
        {
            var url = this.createEntityBuilder.GetUrlForRequest(request);

            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Post, url);

			string serializedEvent = JsonConvert.SerializeObject(request.Event);

			StringContent bodycontent = new StringContent(serializedEvent, Encoding.UTF8, "application/json");

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


				return UTTrackEventResponseParser.Parse(httpData, this.statusCode, cancelToken);
            };
            return await Task.Factory.StartNew(syncParseResponse, cancelToken);
        }

      

        private void Validate()
        {
            if (null == this.httpClient)
            {
                throw new ArgumentNullException("CreateEntityTask.httpClient cannot be null");
            }

            if (null == this.createEntityBuilder)
            {
                throw new ArgumentNullException("CreateEntityTask.createEntityBuilder cannot be null");
            }
        }

        private int statusCode = 0;

    }
}