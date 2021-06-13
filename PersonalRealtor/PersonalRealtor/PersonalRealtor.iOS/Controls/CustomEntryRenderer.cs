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
				// do whatever you want to the UITextField here!
				//Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
				//Control.BorderStyle = UITextBorderStyle.Line;
			}
		}
	}
}
