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
            // Perform any additional setup after loading the view, typically from a nib.






            using (


            var session = SitecoreUTSessionBuilder.SessionWithHost(this.instanceUrl)
                .BuildSession();



            )
            {

                var request = UTRequestBuilder.TrackEventRequest("eventID")
                                                       .Build();


                var response = await session.TrackEventAsync(request);

                Console.WriteLine("RESULT: " + response.ToString());

                if (response.Any())
                {
                    this.ShowItemsList(response);
                }
                else
                {
                    AlertHelper.ShowLocalizedAlertWithOkOption("Message", "Item is not exist");
                }
            }



        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
