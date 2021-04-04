using System;
using PersonalRealtor.Models;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PropertyListingDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePropertyListing { get; set; }

        public PropertyListingDataTemplateSelector()
        {
            DataTemplatePropertyListing = new DataTemplate(typeof(PropertyListingViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is PropertyListing)
            {
                return DataTemplatePropertyListing;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
