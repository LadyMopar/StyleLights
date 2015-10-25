using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace StyleLights
{
	[Activity (Label = "StyleLights", MainLauncher = true)]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource	
			SetContentView (Resource.Layout.MainSelectionScreen);

            //attempt to make a spinner
            //Spinner spin = FindViewById<Spinner>(Resource.Id.spinner);

            //spin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spin_ItemSelected);
            //var adapter = ArrayAdapter.CreateFromResource(
            //    this, Resource.Array.mock_device_data_array, Android.Resource.Layout.SimpleSpinnerItem);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //spin.Adapter = adapter;

			//Button presets = FindViewById<Button> (Resource.Id.PresetsButton);
			//presets.Click += delegate {
					
			//};


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


		}
		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}


