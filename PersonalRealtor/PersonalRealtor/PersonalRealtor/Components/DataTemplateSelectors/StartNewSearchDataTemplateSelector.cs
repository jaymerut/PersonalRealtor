using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors {
    public class StartNewSearchDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DataTemplateAutocompleteLocationGroupName { get; set; }
        public DataTemplate DataTemplateAutocompleteLocation { get; set; }

        public StartNewSearchDataTemplateSelector() {
            DataTemplateAutocompleteLocationGroupName = new DataTemplate(typeof(AutocompleteLocationGroupNameViewCell));
            DataTemplateAutocompleteLocation = new DataTemplate(typeof(AutocompleteLocationViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is AutocompleteLocationViewModel) {
                return DataTemplateAutocompleteLocation;
            } else if (item is AutocompleteLocationGroupNameViewModel) {
                return DataTemplateAutocompleteLocationGroupName;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
