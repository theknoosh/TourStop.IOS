using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace TourStop.IOS {
	class TourStopTableCell : UITableViewCell {
		UILabel nameLabel;
		UIButton mapButton, callButton;
		public TourStopTableCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId) {
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.FromRGB(133, 155, 127);

			var newFont = UIFont.SystemFontOfSize(12);
			nameLabel = new UILabel();
			nameLabel.Font = newFont;

				

			mapButton = new UIButton();
			mapButton.Font = newFont;
			mapButton.SetTitle("Map", UIControlState.Normal);

			callButton = new UIButton();
			callButton.Font = newFont;
			ContentView.AddSubviews(new UIView[] { nameLabel, mapButton, callButton});

		}
		
		public UIButton MapButton {
			get {
				return mapButton; }
		}
		public UIButton CallButton
		{
			get
			{
				return callButton;
			}
		}
		public void UpdateCellControlsWithTourData(string tourName, string phone) {

			nameLabel.Text = tourName;
			callButton.SetTitle(phone, UIControlState.Normal);
		
			
		}

		public override void LayoutSubviews() {
			base.LayoutSubviews();
			nameLabel.Frame = new CGRect(10, 0, 150, 33);
			mapButton.Frame = new CGRect(170, 0, 30, 33);
			callButton.Frame = new CGRect(200, 0, 80, 33);
		}

	}
}
