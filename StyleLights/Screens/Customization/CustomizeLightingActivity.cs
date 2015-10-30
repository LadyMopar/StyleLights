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
	[Activity (Label = "CustomizeLightingActivity")]
	public class CustomizeLightingActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.CustomizeLighting);

			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

			LinearLayout topButtons = FindViewById<LinearLayout> (Resource.Id.linearLayout20);
			LinearLayout topSections = FindViewById<LinearLayout> (Resource.Id.linearLayout6);
			LinearLayout saveShare = FindViewById<LinearLayout> (Resource.Id.linearLayout16);
			LinearLayout tabsBottom = FindViewById<LinearLayout> (Resource.Id.linearLayout21);
			LinearLayout bottomButtons = FindViewById<LinearLayout> (Resource.Id.linearLayout12);

			topButtons.SetMinimumWidth (widthInDp);
			topButtons.SetMinimumHeight (heightInDp * (1/9) );
			topSections.SetMinimumWidth (widthInDp);
			topSections.SetMinimumHeight (heightInDp * (1/3) );
			saveShare.SetMinimumWidth (widthInDp);
			saveShare.SetMinimumHeight (heightInDp * (1/9) );
			tabsBottom.SetMinimumWidth (widthInDp);
			tabsBottom.SetMinimumHeight (heightInDp * (1/9) );
			topButtons.SetMinimumWidth (widthInDp);
			topButtons.SetMinimumHeight (heightInDp * (1/3) );

			var selectionButton = FindViewById<Button> (Resource.Id.selectionButton);

			if (selectionButton != null) {
				selectionButton.Click += (sender, e) => {
					var activity = new Intent(this, typeof(MainActivity));
					StartActivity(activity);
				};
			}

		}

		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}

