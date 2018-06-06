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

    internal class TrackInteractionTask<T> : IRestApiCallTasks<T, HttpRequestMessage, string, UTInteractionResponse>
        where T : class, ITrackInteractionRequest

    {
        private readonly TrackInteractionUrlBuilder<T> trackInteractionUrlBuilder;
        private readonly HttpClient httpClient;

        public TrackInteractionTask(
            TrackInteractionUrlBuilder<T> trackInteractionUrlBuilder,
            HttpClient httpClient)
        {
            this.trackInteractionUrlBuilder = trackInteractionUrlBuilder;
            this.httpClient = httpClient;

            this.Validate();
        }

        public HttpRequestMessage BuildRequestUrlForRequestAsync(T request, CancellationToken cancelToken)
        {
            var url = this.trackInteractionUrlBuilder.GetUrlForRequest(request);

            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Post, url);

            string serializedInteraction = JsonConvert.SerializeObject(request.Interaction);

            StringContent bodycontent = new StringContent(serializedInteraction, Encoding.UTF8, "application/json");

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

        public async Task<UTInteractionResponse> ParseResponseDataAsync(string httpData, CancellationToken cancelToken)
        {
            Func<UTInteractionResponse> syncParseResponse = () =>
            {
                //TODO: @igk debug response output, remove later
                Debug.WriteLine("RESPONSE: " + httpData);


                return UTResponseParser.ParseInteraction(httpData, this.statusCode, cancelToken);
            };
            return await Task.Factory.StartNew(syncParseResponse, cancelToken);
        }



        private void Validate()
        {
            if (null == this.httpClient)
            {
                throw new ArgumentNullException("TrackInteractionTask.httpClient cannot be null");
            }

            if (null == this.trackInteractionUrlBuilder)
            {
                throw new ArgumentNullException("TrackInteractionTask.trackInteractionBuilder cannot be null");
            }
        }

        private int statusCode = 0;

    }
}