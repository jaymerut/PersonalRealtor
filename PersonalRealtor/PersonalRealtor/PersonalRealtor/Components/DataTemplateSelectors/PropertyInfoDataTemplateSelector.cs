using System;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PropertyInfoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePropertyListing { get; set; }

        public PropertyInfoDataTemplateSelector()
        {

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
