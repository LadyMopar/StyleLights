
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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

			//Variable declarations
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);

			//Buttons
			Button selectionButton = FindViewById<Button> (Resource.Id.selectionButton);
			Button lightingButton = FindViewById<Button> (Resource.Id.lightingButton);
			Button saveButton = FindViewById<Button> (Resource.Id.saveButton);
			Button color1 = FindViewById<Button> (Resource.Id.color1);

			//EditText
			EditText redText = FindViewById<EditText> (Resource.Id.redText);
			EditText greenText = FindViewById<EditText> (Resource.Id.greenText);
			EditText blueText = FindViewById<EditText> (Resource.Id.blueText);
			EditText hueText = FindViewById<EditText> (Resource.Id.hueText);
			EditText satText = FindViewById<EditText> (Resource.Id.satText);
			EditText valText = FindViewById<EditText> (Resource.Id.valText);

			redText.Text = "0";
			greenText.Text = "0";
			blueText.Text = "0";
			hueText.Text = "0";
			satText.Text = "0";
			valText.Text = "0";

			//Other Stuff
			Spinner colorSpinner = FindViewById<Spinner> (Resource.Id.colorSpinner);

			//Spinner stuff
			colorSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (colorSpinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.color_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			colorSpinner.Adapter = adapter;

			//EditText stuff

			redText.KeyPress += (object sender, View.KeyEventArgs e) => {
				e.Handled = false;

				if(e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
					string hex = RGBtoHex(redText, blueText, greenText);
					color1.Text = hex;
					e.Handled = true;


				}
			};
			
			greenText.KeyPress += (object sender, View.KeyEventArgs e) => {
				e.Handled = false;
				
				if(e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
					string hex = RGBtoHex(redText, blueText, greenText);
					color1.Text = hex;
					e.Handled = true;
				}
			};

			blueText.KeyPress += (object sender, View.KeyEventArgs e) => {
				e.Handled = false;

				if(e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
					string hex = RGBtoHex(redText, blueText, greenText);
					color1.Text = hex;
					e.Handled = true;

				}
			};


			//"Tab" stuff
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

		//Pixel converter (not really being used)
		private int ConvertPixelsToDp(float pixels) {
			var dp = (int) ((pixels) / Resources.DisplayMetrics.Density);
			return dp;
		}

		//Spinner Method
		private void colorSpinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format ("Selected: {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}

		private string RGBtoHex(EditText redText, EditText blueText, EditText greenText) {
			Console.WriteLine ("Made it this far!");
			int redInt = Int32.Parse(redText.Text);
			int greenInt = Int32.Parse(greenText.Text);
			int blueInt = Int32.Parse(blueText.Text);

			if (redInt < 0 || redInt >= 256) {
				Console.WriteLine ("You probably won't see me!");
				string toast = string.Format ("Could not parse {0} to an int. Try another value between 0 and 255.", redText.Text);
				Toast.MakeText (this, toast, ToastLength.Long).Show ();
				redInt = 0;
			}

			if (greenInt < 0 || greenInt >= 256) {
				string toast = string.Format ("Could not parse {0} to an int. Try another value between 0 and 255.", greenText.Text);
				Toast.MakeText (this, toast, ToastLength.Long).Show ();
				greenInt = 0;
			}

			if (blueInt < 0 || blueInt >= 256) {
				string toast = string.Format ("Could not parse {0} to an int. Try another value between 0 and 255.", blueText.Text);
				Toast.MakeText (this, toast, ToastLength.Long).Show ();
				blueInt = 0;
			}

			Color color = Color.FromArgb (redInt, greenInt, blueInt);

			string hex = color.R.ToString ("X2") + color.B.ToString ("X2") + color.G.ToString ("X2");

			return hex;
		}
	}
}

