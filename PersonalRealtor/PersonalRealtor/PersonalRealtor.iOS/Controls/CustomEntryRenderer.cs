using System;
using PersonalRealtor.Controls;
using PersonalRealtor.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PersonalRealtor.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Layer.BorderColor = Color.FromHex("#9B9B9B").ToCGColor();
				Control.Layer.BorderWidth = 1;
				Control.Layer.CornerRadius = 6;
			}
		}
	}
}

