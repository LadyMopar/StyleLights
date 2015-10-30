
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
	[Activity (Label = "CustomizeColorActivity")]			
	public class CustomizeColorActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.CustomizeColor);

			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

			var selectionButton = FindViewById<Button> (Resource.Id.selectionButton);
			var lightingButton = FindViewById<Button> (Resource.Id.lightingButton);
			var saveButton = FindViewById<Button> (Resource.Id.saveButton);

			if (selectionButton != null) {
				selectionButton.Click += (sender, e) => {
					var activity = new Intent(this, typeof(MainActivity));
					StartActivity(activity);
				};
			}


			if (lightingButton != null) {
				lightingButton.Click += (sender, e) => {
					var activity = new Intent(this, typeof(CustomizeLightingActivity));
					StartActivity(activity);
				};
			}

			saveButton.Click+= (sender, e) => {
				Toast.MakeText(this, "Pattern has been saved", ToastLength.Long).Show();
			};

		}

		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}

