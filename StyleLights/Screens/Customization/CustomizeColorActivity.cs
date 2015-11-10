
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
		string red = "0";
		string green = "0";
		string blue = "0";
		string hex = "000000";
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.CustomizeColor);

			//Variable declarations
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp (metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp (metrics.HeightPixels);


			//Color 1 = False, Color 2 = True

			//Buttons
			Button selectionButton = FindViewById<Button> (Resource.Id.selectionButton);
			Button lightingButton = FindViewById<Button> (Resource.Id.lightingButton);
			Button saveButton = FindViewById<Button> (Resource.Id.saveButton);
			Button color1 = FindViewById<Button> (Resource.Id.color1);
			Button color2 = FindViewById<Button> (Resource.Id.color2);
			Button reset = FindViewById<Button> (Resource.Id.reset);

			//EditText
			EditText redText = FindViewById<EditText> (Resource.Id.redText);
			EditText greenText = FindViewById<EditText> (Resource.Id.greenText);
			EditText blueText = FindViewById<EditText> (Resource.Id.blueText);
//			redText.SetFilters (new global::Android.Text.IInputFilter[]{ global::Android.Text.InputFilterLengthFilter (3)});
//			greenText.SetFilters (new global::Android.Text.IInputFilter[]{ global::Android.Text.InputFilterLengthFilter (3)});
//			blueText.SetFilters (new global::Android.Text.IInputFilter[]{ global::Android.Text.InputFilterLengthFilter (3)});

//			redText.Text = "0";
//			greenText.Text = "0";
//			blueText.Text = "0";
//			hueText.Text = "0";
//			satText.Text = "0";
//			valText.Text = "0";

			//Other Stuff
			Spinner colorSpinner = FindViewById<Spinner> (Resource.Id.colorSpinner);

			//Button Stuff
			if (color1 != null) {
				color1.Click += (sender, e) => {
					color1.Text = hex;
				};
			}

			if (color2 != null) {
				color2.Click += (sender, e) => {
					color2.Text = hex;
				};
			}

			reset.Click += (sender, e) => {
				color1.Text = "";
				color2.Text = "";
				redText.Text = "";
				greenText.Text = "";
				blueText.Text = "";
				red = "0";
				green = "0";
				blue = "0";
				colorSpinner.SetSelection(0);
			};

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
					if (redText.Text != "") {
						red = redText.Text;
					}
					hex = RGBtoHex((double)Int32.Parse(red), (double)Int32.Parse(green), (double)Int32.Parse(blue), redText, greenText, blueText);
//					if (colorOneOrTwo) {
//						color2.Text = hex;
//					} else {
//						color1.Text = hex;
//					}
					e.Handled = true;
				}
			};
			
			greenText.KeyPress += (object sender, View.KeyEventArgs e) => {
				e.Handled = false;
				
				if(e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
					if (greenText.Text != "") {
						green = greenText.Text;
					}
					hex = RGBtoHex((double)Int32.Parse(red), (double)Int32.Parse(green), (double)Int32.Parse(blue), redText, greenText, blueText);
//					if (colorOneOrTwo) {
//						color2.Text = hex;
//					} else {
//						color1.Text = hex;
//					}
					e.Handled = true;
				}
			};

			blueText.KeyPress += (object sender, View.KeyEventArgs e) => {
				e.Handled = false;

				if(e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
					if (blueText.Text != "") {
						blue = blueText.Text;
					}
					hex = RGBtoHex((double)Int32.Parse(red), (double)Int32.Parse(green), (double)Int32.Parse(blue), redText, greenText, blueText);
//					if (colorOneOrTwo) {
//						color2.Text = hex;
//					} else {
//						color1.Text = hex;
//					}
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

		private string RGBtoHex(double redInt, double greenInt, double blueInt, EditText red, EditText green, EditText blue) {

			if (redInt < 0 || redInt >= 256) {
				string toast = string.Format ("Could not parse {0} to an int. Try another value between 0 and 255.", redInt);
				red.Text = "0";
				Toast.MakeText (this, toast, ToastLength.Long).Show ();
				redInt = 0;
			}

			if (greenInt < 0 || greenInt >= 256) {
				string toast = string.Format ("Could not parse {0} to an int. Try another value between 0 and 255.", greenInt);
				green.Text = "0";
				Toast.MakeText (this, toast, ToastLength.Long).Show ();
				greenInt = 0;
			}

			if (blueInt < 0 || blueInt >= 256) {
				string toast = string.Format ("Could not parse {0} to an int. Try another value between 0 and 255.", blueInt);
				blue.Text = "0";
				Toast.MakeText (this, toast, ToastLength.Long).Show ();
				blueInt = 0;
			}

			Color color = Color.FromArgb ((int)redInt, (int)greenInt, (int)blueInt);

			string hex = color.R.ToString ("X2") + color.B.ToString ("X2") + color.G.ToString ("X2");

			return hex;
		}
	}
}

