using System;
using Android.Content;
using Android.Graphics.Drawables;
using PersonalRealtor.Controls;
using PersonalRealtor.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PersonalRealtor.Droid.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Resource.Color.HoloRedDark);
                gd.SetCornerRadius(6);
                gd.SetStroke(2, Color.FromHex("9B9B9B").ToAndroid());
                Control.SetBackground(gd);
            }
        }
    }
}
