using System;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PhotoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePhoto { get; set; }

        public PhotoDataTemplateSelector()
        {

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
