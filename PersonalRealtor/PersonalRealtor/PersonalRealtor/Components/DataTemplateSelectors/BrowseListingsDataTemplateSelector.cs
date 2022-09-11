using System;
using PersonalRealtor.Models;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors {
    public class BrowseListingsDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DataTemplatePropertyListing { get; set; }
        public DataTemplate DataTemplateBrowseListingsAutocomplete { get; set; }

        public BrowseListingsDataTemplateSelector() {
            DataTemplatePropertyListing = new DataTemplate(typeof(PropertyListingViewCell));
            DataTemplateBrowseListingsAutocomplete = new DataTemplate(typeof(BrowseListingsAutocompleteViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is PropertyListing) {
                return DataTemplatePropertyListing;
            } else if (item is BrowseListingsAutocompleteViewModel) {
                return DataTemplateBrowseListingsAutocomplete;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
