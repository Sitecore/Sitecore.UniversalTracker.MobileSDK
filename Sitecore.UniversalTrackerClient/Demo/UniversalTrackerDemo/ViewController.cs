
namespace UniversalTrackerDemo
{
    using System;
    using System.Collections.Generic;
    using Sitecore.UniversalTrackerClient.Entities;
    using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
    using Sitecore.UniversalTrackerClient.Session.SessionBuilder;
    using UIKit;

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
            var defaultInteraction = UTEntitiesBuilder.Interaction()
                                                      .ChannelId("27b4e611-a73d-4a95-b20a-811d295bdf65")
                                                      .Initiator(InteractionInitiator.Contact)
                                                      .Contact("jsdemo", "demo")
                                                      .Build();
            using
               (
                    var session = SitecoreUTSessionBuilder.SessionWithHost("https://utwebtests")
                                                          .TokenValue("SecretTOken")
                                                          .DefaultInteraction(defaultInteraction)
                                                          .DeviceIdentifier(UIDevice.CurrentDevice.IdentifierForVendor.ToString())
                                                          .BuildSession()
               )
            {

                //#region Track_Interaction

                //var interactionRequest = UTRequestBuilder.Interaction(UTEvent.GetEmptyEvent())
                //                                         .ChannelId("27b4e611-a73d-4a95-b20a-811d295bdf65")
                //                                         .EndDateTime(DateTime.Now)
                //                                         .Initiator(InteractionInitiator.Contact)
                //                                         .Contact("jsdemo", "demo")
                //                                         .Build();

                //var interactionResponse = await session.TrackInteractionAsync(interactionRequest);
                //Console.WriteLine("Track INTERACTION RESULT: " + interactionResponse.StatusCode.ToString());


                //#endregion Track_Interaction

                #region Track_Base_Event

                Dictionary<string, string> customParameters = new Dictionary<string, string>();
                customParameters.Add("param11", "paramValue11");
                customParameters.Add("param22", "paramValue22");
                customParameters.Add("param33", "paramValue33");
                //customParameters.Add("key2", "value2"); //error expected, testing duplicated keys

                var eventRequest = UTRequestBuilder.EventWithDefenitionId("01f8ffbf-d662-4a87-beee-413307055c48")
                                                   .AddCustomValues("key1", "value1")
                                                   .AddCustomValues("key2", "value2")
                                                   .AddCustomValues(customParameters)
                                                   .ParentEventId("01f8ffbf-d662-4a87-beee-413307055c48")
                                                   .Timestamp(DateTime.Now)
                                                   .Build();

                var eventResponse = await session.TrackEventAsync(eventRequest);
                Console.WriteLine("Track EVENT RESULT: " + eventResponse.StatusCode.ToString());

                #endregion Track_Base_Event

                #region Track_PageView

                var pageViewRequest = UTRequestBuilder.PageViewWithDefenitionId("01f8ffbf-d662-4a87-beee-413307055c48")
                                                      .Timestamp(DateTime.Now)
                                                      .ItemId("01f8ffbf-d662-4a87-beee-413307055c48")
                                                      .ItemVersion(1)
                                                      .ItemLanguage("en")
                                                      .AddCustomValues("key", "value")
                                                      .Build();

                var pageViewResponse = await session.TrackPageViewEventAsync(pageViewRequest);
                Console.WriteLine("Track PAGEVIEW EVENT RESULT: " + pageViewResponse.StatusCode.ToString());

                #endregion Track_PageView

                #region Track_Search

                var searchRequest = UTRequestBuilder.SearchEvent("01f8ffbf-d662-4a87-beee-413307055c48")
                                                    .Timestamp(DateTime.Now)
                                                    .Keywords("blablabla")
                                                    .AddCustomValues("key", "value")
                                                    .Build();

                var searchResponse = await session.TrackSearchEventAsync(searchRequest);
                Console.WriteLine("Track SEARCH EVENT RESULT: " + searchResponse.StatusCode.ToString());

                #endregion Track_search

                #region Track_Location_Event

                double lat = 37.342454;
                double lon = -122.342454;

                var locationEventRequest = UTRequestBuilder.LocationEvent(lat, lon)
                                                           .DefinitionId("01f8ffbf-d662-4a87-beee-413307055c48")
                                                           .Timestamp(DateTime.Now)
                                                           .Build();

                var locationEventResponse = await session.TrackLocationEventAsync(locationEventRequest);
                Console.WriteLine("Track LOCATION EVENT RESULT: " + locationEventResponse.StatusCode.ToString());

                #endregion Track_Location_Event

                #region Track_Error_Event

                string error = "PARSER_EXEPTION";
                string errorDescription = "something went wrong while parsing event response";

                var errorEventRequest = UTRequestBuilder.ErrorEvent(error, errorDescription)
                                                        .Build();
                
                var errorEventResponse = await session.TrackErrorEventAsync(errorEventRequest);
                Console.WriteLine("Track ERROR EVENT RESULT: " + errorEventResponse.StatusCode.ToString());
               
                #endregion Track_Error_Event

                #region App_Launched_Event

                var appLaunchedEventRequest = UTRequestBuilder.AppLaunchedEvent()
                                                              .Build();

                var appLaunchedEventResponse = await session.TrackEventAsync(appLaunchedEventRequest);
                Console.WriteLine("Track APP LAUNCHED EVENT RESULT: " + appLaunchedEventResponse.StatusCode.ToString());

                #endregion App_Launched_Event

                #region App_Finished_Event

                var appFinishedEventRequest = UTRequestBuilder.AppFinishedEvent()
                                                              .Build();

                var appFinishedEventResponse = await session.TrackEventAsync(appFinishedEventRequest);
                Console.WriteLine("Track APP FINISHED EVENT RESULT: " + appFinishedEventResponse.StatusCode.ToString());

                #endregion App_Finished_Event

                #region Page_Opened_Event

                DateTime timeStamp = DateTime.UtcNow;

                var pageOpenedEventRequestRB = UTRequestBuilder.PageOpenedEvent("pageId", timeStamp);
                var pageOpenedEventRequest = pageOpenedEventRequestRB.Build();
                                                             

                var pageOpenedEventResponse = await session.TrackEventAsync(pageOpenedEventRequest);

                Console.WriteLine("Track APP LAUNCHED EVENT RESULT: " + pageOpenedEventResponse.StatusCode.ToString());

                #endregion Page_Opened_Event

                #region Page_Closed_Event

                var pageClosedEventRequest = UTRequestBuilder.PageClosedEvent("pageId", timeStamp)
                                                             .Build();

                var pageClosedEventResponse = await session.TrackEventAsync(pageClosedEventRequest);
                Console.WriteLine("Track APP FINISHED EVENT RESULT: " + pageClosedEventResponse.StatusCode.ToString());

                #endregion Page_Closed_Even


                #region Outcome_Event

                var outcome = UTRequestBuilder.OutcomeWithDefenitionId("01f8ffbf-d662-4a87-beee-413307055c48")
                                               .Text("")
                                               .CurrencyCode("bla")
                                               .MonetaryValue(11)
                                               .Build();

                var outcomeResponse = await session.TrackOutcomeEventAsync(outcome);
                Console.WriteLine("Track APP FINISHED EVENT RESULT: " + outcomeResponse.StatusCode.ToString());

                #endregion Outcome_Event


                #region Device_Info

                UIDevice deviceInfo = UIDevice.CurrentDevice;

                var deviceInfoRequest = UTRequestBuilder.DeviceInformationEvent(deviceInfo.Name)
                                                        .DeviceIdentifier("bugaga")
                                                        .BatteryLevel(deviceInfo.BatteryLevel)
                                                        .OperatingSystem(deviceInfo.SystemName, deviceInfo.SystemVersion)
                                                        .Build();

                var deviceInfoResponse = await session.TrackEventAsync(deviceInfoRequest);
                Console.WriteLine("Track DEVICE INFO EVENT RESULT: " + deviceInfoResponse.StatusCode.ToString());

                #endregion Device_Info
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
