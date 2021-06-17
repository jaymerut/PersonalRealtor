using System;
using PersonalRealtor.Controls;
using PersonalRealtor.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace PersonalRealtor.iOS.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
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
