using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace login
{
    [Activity(Label = "WebViewer", Theme = "@style/AppTheme.NoActionBar")]
    public class WebViewer : Activity
    {
        WebView webView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.web_view);



            webView = FindViewById<WebView>(Resource.Id.WebView);
            webView.SetWebViewClient(new WebViewClient());
            webView.LoadUrl("http://www.xamarin.com");
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.SetSupportZoom(true);
            webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            webView.ScrollbarFadingEnabled = false;

        }

    }
}