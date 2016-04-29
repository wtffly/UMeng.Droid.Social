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
using Com.Umeng.Socialize;

namespace UMeng.Social.Sample
{
    public class App : Application
    {
        protected App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            InitUmengShare();
        }

        private void InitUmengShare()
        {

            //PlatformConfig.SetSinaWeibo("3921700954", "04b48b094faeb16683c32669824ebdad");
        }
    }
}