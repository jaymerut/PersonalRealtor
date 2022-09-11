using System;
using PersonalRealtor.Models;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors {
    public class StartNewSearchDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DataTemplateAutocompleteLocation { get; set; }

        public StartNewSearchDataTemplateSelector() {
            DataTemplateAutocompleteLocation = new DataTemplate(typeof(AutocompleteLocationViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is AutocompleteLocation) {
                return DataTemplateAutocompleteLocation;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
