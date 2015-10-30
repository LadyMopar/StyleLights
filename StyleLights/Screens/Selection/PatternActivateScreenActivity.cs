
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace StyleLights
{
	[Activity (Label = "PatternActivateScreenActivity")]			
	public class PatternActivateScreenActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.PatternActivateScreen);
			// Create your application here
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);
		
			LinearLayout layoutTest = FindViewById<LinearLayout> (Resource.Id.linearLayoutPtrnActvt3);
			LinearLayout layoutTest2 = FindViewById<LinearLayout> (Resource.Id.linearLayoutPtrnActvt1);
			LinearLayout layoutTest3 = FindViewById<LinearLayout> (Resource.Id.linearLayoutPtrnActvt2);
			layoutTest.SetMinimumWidth (widthInDp);
			layoutTest.SetMinimumHeight (heightInDp * (5/6) );
			layoutTest2.SetMinimumWidth (widthInDp);
			layoutTest2.SetMinimumHeight (heightInDp * (1 / 10));
			layoutTest3.SetMinimumWidth (widthInDp);
			layoutTest3.SetMinimumHeight (heightInDp * (1 / 10));

			//get name of pattern from intent
			string patternName = Intent.GetStringExtra ("Pattern Name")?? "Pattern Name not found";
			var nameStr = FindViewById<TextView> (Resource.Id.textView1);
			nameStr.Text= patternName;
			//Find our controls
			var activateButton = FindViewById<Button>(Resource.Id.ActivateButton);
			var selectionButton = FindViewById<Button> (Resource.Id.SelectionButton);
			var customizationButton = FindViewById<Button> (Resource.Id.CustomizeButton);

			//Wire up controls
			activateButton.Click+= (sender, e) => {
				Toast.MakeText(this, "Pattern: "+patternName+" has been sent to the device", ToastLength.Long).Show();
			};
			if (selectionButton != null) {
				selectionButton.Click+= (sender, e) => {
					StartActivity(typeof(MainActivity));
				};
			}
			if (customizationButton!=null)
				customizationButton.Click+= (sender, e) => {
				var activity = new Intent(this, typeof(CustomizeColorActivity));
				StartActivity(activity);
			};
		}

		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}

