using System;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;

namespace IotPoc
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program.SendBaseEventRequest();
        }

        public static async void SendBaseEventRequest()
        {
            var defaultInteraction = UTEntitiesBuilder.Interaction()
                                                      .ChannelId("27b4e611-a73d-4a95-b20a-811d295bdf65")
                                                      .Initiator(InteractionInitiator.Contact)
                                                      .Contact("jsdemo", "demo")
                                                      .Build();

            using (var session = SitecoreUTSessionBuilder.SessionWithHost("https://utwebtests")
                                                   .DefaultInteraction(defaultInteraction)
                                                   .BuildSession()
                  )
            {
                string definitionId = "01f8ffbf-d662-4a87-beee-413307055c48";

                var eventRequest = UTRequestBuilder.EventWithDefenitionId(definitionId)
                                                   .AddCustomValues("key1", "value1")
                                                   .Timestamp(DateTime.Now)
                                                   .AddCustomValues("igk", "demo")
                                                   .Build();

                var eventResponse = await session.TrackEventAsync(eventRequest);

                Console.WriteLine("Track EVENT RESULT: " + eventResponse.StatusCode.ToString());
            }
        }
    }
}
