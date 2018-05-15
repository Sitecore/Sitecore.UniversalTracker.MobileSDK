using System;
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

                var request = UTRequestBuilder.TrackEventRequestForItem("eventID")
                                              .Build();

                var response = await session.TrackEventAsync(request);

                Console.WriteLine("RESULT: " + response.ToString());

            }

		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
