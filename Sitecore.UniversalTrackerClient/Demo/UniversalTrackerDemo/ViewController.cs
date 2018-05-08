using System;

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

            using 
                (
                var session = SitecoreUTSessionBuilder.SessionWithHost(this.instanceUrl)
                                                      .BuildSession()

                )
            {

                var request = UTRequestBuilder.TrackEventRequest("eventID")
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
