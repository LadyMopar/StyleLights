
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
	[Activity (Label = "PatternSelectionScreenCustomActivity")]			
	public class PatternSelectionScreenCustomActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);


			LinearLayout layoutTest2 = FindViewById<LinearLayout> (Resource.Id.linearLayoutCstmSlct1);
			LinearLayout layoutTest3 = FindViewById<LinearLayout> (Resource.Id.linearLayoutCstmSlctn2);
			layoutTest2.SetMinimumWidth (widthInDp);
			layoutTest2.SetMinimumHeight (heightInDp * (1 / 10));
			layoutTest3.SetMinimumWidth (widthInDp);
			layoutTest3.SetMinimumHeight (heightInDp * (1 / 10));
		}

		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}

