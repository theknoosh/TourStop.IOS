using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace TourStop.IOS {

	class TourStopsTableSource : UITableViewSource {
		private List<TourLib.TourStop> _stops;
		NSString _cellID = new NSString("TableCell");
		public TourStopsTableSource() {
			_stops = TourLib.TourSource.GetAllTourStops();
		}
		
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			// tell the TableView how many rows to create
			return _stops.Count;
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
			TourLib.TourStop currentTourStop = _stops[indexPath.Row];
			
			var cell = tableView.DequeueReusableCell(_cellID) as TourStopTableCell;
			if (cell == null) { cell = new TourStopTableCell(_cellID); }
			

			cell.UpdateCellControlsWithTourData(currentTourStop.Name, currentTourStop.Phone);

			#region SetupMapButton
			string mapUrl = String.Format("http://maps.google.com/maps?q={0}+{1}",
																				currentTourStop.Latitude,
																				currentTourStop.Longitude);
			cell.MapButton.TouchUpInside += delegate (object sender, EventArgs e)
			{
				UIApplication.SharedApplication.OpenUrl(new NSUrl(mapUrl));
			}; 
			#endregion
			cell.CallButton.TouchUpInside += CallNumber;

			return cell;
		}

		private void CallNumber(object sender, EventArgs e) {
			var button = sender as UIButton;
			var phoneNumber = button.Title(UIControlState.Normal);
			var url = new Foundation.NSUrl("tel:" + phoneNumber);
			var alert = UIAlertController.Create("Alert", "Simulated call to  " + phoneNumber, UIAlertControllerStyle.Alert);

			alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
			UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
		}
	
	}
}
