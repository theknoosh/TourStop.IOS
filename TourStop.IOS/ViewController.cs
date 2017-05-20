using System;

using UIKit;

namespace TourStop.IOS
{
    public partial class ViewController : UIViewController
    {
       

        partial void CallButton2_TouchUpInside(UIButton sender)
        {
            CallNumber("555-2424");
        }

        partial void CallButton1_TouchUpInside(UIButton sender)
        {
			CallNumber("555-1212");
		}

		private Foundation.NSUrl url;

		private void CallNumber(string phoneNumber)
		{
			url = new Foundation.NSUrl("tel:" + phoneNumber);
			var alert = UIAlertController.Create("Alert", "Simulated call to  " + phoneNumber, UIAlertControllerStyle.Alert);

			alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, MakeCallAction));
			alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, MakeCallAction));
			PresentViewController(alert, true, null);

		}

		private void MakeCallAction(UIAlertAction action)
		{
			bool wasSuccessful = UIApplication.SharedApplication.OpenUrl(url);
		}


		private const int TimePerStop = 45; // minutes
		private double CalculateTourDuration(int numberOfStops, double speedRatio)
		{
			// some code for debugging demo

			var temp = numberOfStops;
			var duration = (numberOfStops * TimePerStop) * speedRatio;
			return duration;
		}

        partial void CalcButton_TouchUpInside(UIButton sender)
        {
            var duration = new TourLib.Duration();
            double result = duration.CalculateTourDuration(numberOfStops: 2, speedRatio: 1.2);
			DurationResult.Text = String.Format("{0} minutes", result);
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
