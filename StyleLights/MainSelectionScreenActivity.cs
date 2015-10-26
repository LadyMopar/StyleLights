using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace StyleLights
{
	[Activity (Label = "MainSelectionScreenActivity", MainLauncher = true)]
	public class MainActivity : Activity
	{
		//int count = 1;
		Button presetButton;
		Button customButton;
		Button newButton;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource	
			SetContentView (Resource.Layout.MainSelectionScreen);

			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

			LinearLayout layoutTest = FindViewById<LinearLayout> (Resource.Id.linearLayout7);
			LinearLayout layoutTest2 = FindViewById<LinearLayout> (Resource.Id.linearLayout6);
			LinearLayout layoutTest3 = FindViewById<LinearLayout> (Resource.Id.linearLayout5);
			layoutTest.SetMinimumWidth (widthInDp);
			layoutTest.SetMinimumHeight (heightInDp * (5/6) );
			layoutTest2.SetMinimumWidth (widthInDp);
			layoutTest2.SetMinimumHeight (heightInDp * (1 / 20));
			layoutTest3.SetMinimumWidth (widthInDp);
			layoutTest3.SetMinimumHeight (heightInDp * (1 / 10));

			//Find our controls
			presetButton = FindViewById<Button>(Resource.Id.PresetsButton);
			customButton = FindViewById<Button> (Resource.Id.CustomButton);
			newButton = FindViewById<Button> (Resource.Id.CreateNewButton);

			//Wire up our controls
			if (presetButton != null) {
				presetButton.Click+= (sender, e) => {
					var activity= new Intent(this, typeof(PatternSelectionScreenPresetsActivity));
					//activity.PutExtra("Pattern Name","Pattern1");
					StartActivity(activity);
				};
			}
			if (customButton != null) {
				customButton.Click+= (sender, e) => {
					StartActivity(typeof(PatternSelectionScreenCustomActivity));
				};
			}

		}
		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}


