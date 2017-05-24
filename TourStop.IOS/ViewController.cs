using System;

using UIKit;

namespace TourStop.IOS
{
    public partial class ViewController : UIViewController
    {
        
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
			var numberOfStops = TableView1.NumberOfRowsInSection(0);
			var duration = new TourLib.Duration();
			double result = duration.CalculateTourDuration(numberOfStops: (int)numberOfStops,
																								speedRatio: 1.2);
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
            TableView1.Source = new TourStopsTableSource();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
