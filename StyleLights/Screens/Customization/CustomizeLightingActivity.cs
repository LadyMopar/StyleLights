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

			//Variable declarations
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

			//Layouts
			LinearLayout topButtons = FindViewById<LinearLayout> (Resource.Id.linearLayout20);
			LinearLayout topSections = FindViewById<LinearLayout> (Resource.Id.linearLayout6);
			LinearLayout saveShare = FindViewById<LinearLayout> (Resource.Id.linearLayout16);
			LinearLayout tabsBottom = FindViewById<LinearLayout> (Resource.Id.linearLayout21);
			LinearLayout bottomButtons = FindViewById<LinearLayout> (Resource.Id.linearLayout12);

			//Buttons
			Button selectionButton = FindViewById<Button> (Resource.Id.selectionButton);
			Button colorButton = FindViewById<Button> (Resource.Id.colorButton);
			Button saveButton = FindViewById<Button> (Resource.Id.saveButton);

			//Other stuff
			Spinner effectSpinner = FindViewById<Spinner> (Resource.Id.effectSpinner);
			SeekBar slider = FindViewById<SeekBar> (Resource.Id.brightnessSlider);
			TextView brightnessVal = FindViewById<TextView> (Resource.Id.brightnessVal);

			brightnessVal.Text = "";
		
			//Slider lambda expression
			slider.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser) {
					brightnessVal.Text = string.Format("Brightness at {0}%" , e.Progress);
				}
			};

			//Spinner lambda
			effectSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (effectSpinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.lighting_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			effectSpinner.Adapter = adapter;


			//Handlers for the "tabs"

			if (selectionButton != null) {
				selectionButton.Click += (sender, e) => {
					var activity = new Intent(this, typeof(MainActivity));
					StartActivity(activity);
				};
			}

			if (colorButton != null) {
				colorButton.Click += (sender, e) => {
					var activity = new Intent(this, typeof(CustomizeColorActivity));
					StartActivity(activity);
				};
			}

			saveButton.Click+= (sender, e) => {
				Toast.MakeText(this, "Pattern has been saved", ToastLength.Long).Show();
			};



			//Not especially useful right now
//			topButtons.SetMinimumWidth (widthInDp);
//			topButtons.SetMinimumHeight (heightInDp * (1/9) );
//			topSections.SetMinimumWidth (widthInDp);
//			topSections.SetMinimumHeight (heightInDp * (1/3) );
//			saveShare.SetMinimumWidth (widthInDp);
//			saveShare.SetMinimumHeight (heightInDp * (1/9) );
//			tabsBottom.SetMinimumWidth (widthInDp);
//			tabsBottom.SetMinimumHeight (heightInDp * (1/9) );
//			topButtons.SetMinimumWidth (widthInDp);
//			topButtons.SetMinimumHeight (heightInDp * (1/3) );
		}

		//Pixel converter (not really being used)
		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}

		//Spinner Method
		private void effectSpinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format ("Selected: {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}

	}
}

