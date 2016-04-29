using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Umeng.Socialize.Handler;
using Com.Umeng.Socialize.Bean;
using Com.Umeng.Socialize;
using Java.Lang;
using Sino.Droid.MaterialDialog.Views;
using Sino.Droid.MaterialDialog;

namespace UMeng.Social.Sample
{
    [Activity(Label = "UMeng.Social.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            string appID = "***********";
            string appSecret = "**************";
            PlatformConfig.SetWeixin(appID, appSecret);
            PlatformConfig.SetQQZone("100424468", "**************");
            PlatformConfig.SetSinaWeibo("295993342", "*****************");
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate 
            {
                new MaterialDialog.Builder(this)
                    .SetTitle("分享")
                    .SetShareCallBack(() =>
                    {
                        ShareInformation(SHARE_MEDIA.Sina);
                    }, ShareType.Sina)
                    .SetShareCallBack(() =>
                    {
                        ShareInformation(SHARE_MEDIA.WeixinCircle);
                    }, ShareType.WXCircle)
                    .SetShareCallBack(() =>
                    {
                        ShareInformation(SHARE_MEDIA.Weixin);
                    }, ShareType.WeiXin)
                    .SetShareCallBack(() =>
                    {
                        ShareInformation(SHARE_MEDIA.Qq);
                    }, ShareType.QQ)
                    .SetShareCallBack(() =>
                    {
                        ShareInformation(SHARE_MEDIA.Tencent);
                    }, ShareType.TencentWeibo)
                    .SetShareCallBack(() =>
                    {
                        ShareInformation(SHARE_MEDIA.Qzone);
                    }, ShareType.Qzone)
                    .SetDialogType(DialogType.MultiShare)
                    .SetNegativeButtonText("取消")
                    .Cancelable(true)
                    .Build()
                    .Show();
            };
        }


        private void ShareInformation(SHARE_MEDIA platform)
        {
            new ShareAction(this)
                     .SetPlatform(platform)
                     .WithText("【来货拉】深入剖析国内物流企业需求，用心打造物流OTO智能平台产品。")
                     .WithTitle("快来下载来货拉")
                     .WithMedia(new Com.Umeng.Socialize.Media.UMImage(this,Resource.Drawable.Icon))
                     .WithTargetUrl("http://www.sowl.cn/sn.html")
                     .SetCallback(new MyUMengShareListener(this))
                     .Share();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            UMShareAPI.Get(this).OnActivityResult(requestCode, (int)resultCode, data);
        }


        private class MyUMengShareListener : Java.Lang.Object, IUMShareListener
        {
            private Context mContext;

            public MyUMengShareListener(Context context)
            {
                this.mContext = context;
            }

            public void OnCancel(SHARE_MEDIA p0)
            {
              
            }

            public void OnError(SHARE_MEDIA p0, Throwable p1)
            {
                
            }

            public void OnResult(SHARE_MEDIA p0)
            {
                Toast.MakeText(mContext, p0+"分享成功", ToastLength.Short).Show();
            }
        }


    }
}

