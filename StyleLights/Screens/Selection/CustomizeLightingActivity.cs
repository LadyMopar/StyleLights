using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace StyleLights
{
	[Activity (Label = "CustomizeLightingActivity")]
	public class CustomizeLightingActivity : Activity
	{
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate (bundle);

			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

	}
		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}

