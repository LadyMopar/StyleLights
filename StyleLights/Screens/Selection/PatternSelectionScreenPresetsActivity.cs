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
	[Activity (Label = "PatternSelectionScreenPresetsActivity")]			
	public class PatternSelectionScreenPresetsActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.PatternSelectionScreenPresets);
			// Create your application here
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

			LinearLayout layoutTest2 = FindViewById<LinearLayout> (Resource.Id.linearLayoutPrst1);
			LinearLayout layoutTest3 = FindViewById<LinearLayout> (Resource.Id.linearLayoutPrst2);
			layoutTest2.SetMinimumWidth (widthInDp);
			layoutTest2.SetMinimumHeight (heightInDp * (1 / 10));
			layoutTest3.SetMinimumWidth (widthInDp);
			layoutTest3.SetMinimumHeight (heightInDp * (1 / 10));

			//Find our controls (hardcoded for now)
			var button1=FindViewById<Button>(Resource.Id.button1);
			var button2=FindViewById<Button>(Resource.Id.button2);
			var button3=FindViewById<Button>(Resource.Id.button3);
			var selectionButton = FindViewById<Button> (Resource.Id.SelectionButton);
			var customizationButton = FindViewById<Button> (Resource.Id.CustomizeButton);

			//wire up our controls
			button1.Click+= (sender, e) => {
				var activity= new Intent(this, typeof(PatternActivateScreenActivity));
				activity.PutExtra("Pattern Name","Preset Pattern 1");
				//activity.AddFlags(ActivityFlags.ClearTop|ActivityFlags.SingleTop);
				StartActivity(activity);
			};
			button2.Click+= (sender, e) => {
				var activity= new Intent(this, typeof(PatternActivateScreenActivity));
				activity.PutExtra("Pattern Name","Preset Pattern 2");
				//activity.AddFlags(ActivityFlags.ClearTop|ActivityFlags.SingleTop);
				StartActivity(activity);
			};
			button3.Click+= (sender, e) => {
				var activity= new Intent(this, typeof(PatternActivateScreenActivity));
				activity.PutExtra("Pattern Name","Preset Pattern 3");
				//activity.AddFlags(ActivityFlags.ClearTop|ActivityFlags.SingleTop);
				StartActivity(activity);
			};
			if (selectionButton != null) {
				selectionButton.Click+= (sender, e) => {
					var activity = new Intent(this, typeof(MainActivity));
					activity.AddFlags(ActivityFlags.ClearTop|ActivityFlags.SingleTop);
					StartActivity(activity);
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

