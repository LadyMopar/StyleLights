using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.IO;

namespace StyleLightsCore
{
	public class Utils
	{
		//store patterns
		private Hashtable patterns;
		const string PatternFileName = "patterns";
		//constructor reads file and closes handles
		public Utils(){
			patterns = new Hashtable ();
			var inputString="";
			using (var input = new FileStream (PatternFileName, System.IO.FileMode.OpenOrCreate)) {
				inputString = input.ToString();
			}
				
		}

		public string getPattern(string PatternName) {
			return (string) patterns[PatternName];//may return null
		}
		public void savePattern(string patternName, string PatternBlob){
			patterns [patternName]=PatternBlob;
		}
	}
}


