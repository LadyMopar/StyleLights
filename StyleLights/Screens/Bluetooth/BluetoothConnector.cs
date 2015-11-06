using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Util;

namespace StyleLights
{
	public class BluetoothConnector
	{
		private const string UuidUniverseProfile = "make a uuid";
		private BluetoothDevice result;
		private BluetoothSocket mSocket;
		private BufferedReader reader;
		private System.IO.Stream mStream;
		private InputStreamReader mReader;





		public BluetoothConnector ()
		{
			reader = null;
		}

		private UUID getUUIDFromString() {
			return UUID.FromString(UuidUniverseProfile);
		}

		private void close(IDisposable aConnectedObject) 
		{
			if (aConnectedObject == null)
				return;

			try 
			{
				aConnectedObject.Dispose();
			}
			catch (IOException e)
			{
				close (mSocket);
				close (mStream);
				close (mReader);
				throw e;
			}
			aConnectedObject = null;
		}

		private void openDeviceConnection(BluetoothDevice btDevice)
		{
			try
			{
				mSocket = btDevice.CreateRfcommSocketToServiceRecord(getUUIDFromString());
				mSocket.Connect();
				mStream = mSocket.InputStream;
				mReader = new InputStreamReader(mStream);
			} 
			catch (IOException e)
			{
				throw e; 
			}
		}
	}
}


