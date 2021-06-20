using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors {
    public class SavedHomesDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DataTemplateSavedHome { get; set; }

        public SavedHomesDataTemplateSelector() {
            DataTemplateSavedHome = new DataTemplate(typeof(SavedHomeViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is SavedHome) {
                return DataTemplateSavedHome;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
