using System;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;
using UIKit;

namespace UniversalTrackerDemo
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.SendRequest();
        }

        private async void SendRequest()
        {
            using
               (
                   var session = SitecoreUTSessionBuilder.SessionWithHost("http://host.com/")
                                                         .BuildSession()

               )
            {

                #region Track_Interaction

                var interactionRequest = UTRequestBuilder.Interaction()
                                                         .CampaignId("someCampId")
                                                         .EndDateTime(DateTime.Now)
                                                         .Initiator(InteractionInitiator.Contact)
                                                         .Build();

                var interactionResponse = await session.TrackInteractionAsync(interactionRequest);
                Console.WriteLine("Track INTERACTION RESULT: " + interactionResponse.ToString());


                #endregion Track_Interaction




                #region Track_Base_Event

                var eventRequest = UTRequestBuilder.EventForItem("01f8ffbf-d662-4a87-beee-413307055c48")
                                              .AddCustomValuesToSet("key1", "value1")
                                              .AddCustomValuesToSet("key2", "value2")
                                              .DefinitionId("someid")
                                              .Duration(new TimeSpan(1000))
                                              .ParentEventId("01f8ffbf-d662-4a87-beee-413307055c48")
                                              .Build();

                var eventResponse = await session.TrackEventAsync(eventRequest);
                Console.WriteLine("Track EVENT RESULT: " + eventResponse.ToString());

                #endregion Track_Base_Event



                #region Track_Location_Event

                double lat = 37.342454;
                double lon = -122.342454;

                var locationEventRequest = UTRequestBuilder.LocationEvent(lat, lon)
                                                           .Build();

                var locationEventResponse = await session.TrackLocationEventAsync(locationEventRequest);
                Console.WriteLine("Track LOCATION EVENT RESULT: " + locationEventResponse.ToString());

                #endregion Track_Location_Event

                #region Track_Error_Event

                string error = "PARSER_EXEPTION";
                string errorDescription = "something went wrong while parsing event response";

                var errorEventRequest = UTRequestBuilder.ErrorEvent(error, errorDescription)
                                                        .Build();
                
                var errorEventResponse = await session.TrackErrorEventAsync(errorEventRequest);
                Console.WriteLine("Track ERROR EVENT RESULT: " + errorEventResponse.ToString());
               
                #endregion Track_Error_Event

                #region App_Launched_Event

                var appLaunchedEventRequest = UTRequestBuilder.AppLaunchedEvent().Build();

                var appLaunchedEventResponse = await session.TrackEventAsync(appLaunchedEventRequest);
                Console.WriteLine("Track APP LAUNCHED EVENT RESULT: " + appLaunchedEventResponse.ToString());

                #endregion App_Launched_Event

                #region App_Finished_Event

                var appFinishedEventRequest = UTRequestBuilder.AppFinishedEvent().Build();

                var appFinishedEventResponse = await session.TrackEventAsync(appFinishedEventRequest);
                Console.WriteLine("Track APP FINISHED EVENT RESULT: " + appFinishedEventResponse.ToString());

                #endregion App_Finished_Event
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
