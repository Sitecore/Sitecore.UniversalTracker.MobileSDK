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

                var eventRequest = UTRequestBuilder.TrackEventForItem("01f8ffbf-d662-4a87-beee-413307055c48")
                                              .AddCustomValuesToSet("key1", "value1")
                                              .AddCustomValuesToSet("key2", "value2")
                                              .DefinitionId("someid")
                                              .Duration(new TimeSpan(1000))
                                              .ParentEventId("01f8ffbf-d662-4a87-beee-413307055c48")
                                              .Build(); 

                var eventResponse = await session.TrackEventAsync(eventRequest);
                Console.WriteLine("Track EVENT RESULT: " + eventResponse.ToString());





                var interactionRequest = UTRequestBuilder.TrackInteraction()
                                                         .CampaignId("someCampId")
                                                         .EndDateTime(DateTime.Now)
                                                         .Initiator(InteractionInitiator.Contact)
                                                         .Build();

                var interactionResponse = await session.TrackInteractionAsync(interactionRequest);
                Console.WriteLine("Track INTERACTION RESULT: " + interactionResponse.ToString());

            }

		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
