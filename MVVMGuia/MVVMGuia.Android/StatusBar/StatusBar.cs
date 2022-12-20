using System;
using Android.App;
using Android.OS;
using Android.Views;
using MVVMGuia.Droid.StatusBar;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBar))]
namespace MVVMGuia.Droid.StatusBar
{
    public class StatusBar : Interfaces.IEventStatusBar
    {
        WindowManagerFlags _originalFlags;

        Window GetCurrentWindow()
        {
            this.ShowStatusBar();
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }

        public void HideStatusBar()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        public void ShowStatusBar()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }

        public void Translucent()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            attrs.Flags |= WindowManagerFlags.TranslucentStatus;
            _originalFlags = attrs.Flags;
            activity.Window.Attributes = attrs;
        }

        public void ChangeColor(string color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                    currentWindow.SetStatusBarColor(global::Android.Graphics.Color.ParseColor(color));
                });
        }

    }
}

