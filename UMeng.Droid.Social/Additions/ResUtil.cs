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

namespace Com.Umeng.Socialize.Utils
{
    public partial class ResUtil:global::Java.Lang.Object
    {
        public partial class FetchTask : Android.OS.AsyncTask
        {
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                return DoInBackgrounds(@params);
            }
         }
    }
}