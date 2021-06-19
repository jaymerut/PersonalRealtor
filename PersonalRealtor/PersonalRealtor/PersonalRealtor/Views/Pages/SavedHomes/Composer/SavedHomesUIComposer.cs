using System;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Views.Pages.SavedHomes.UI;

namespace PersonalRealtor.Views.Pages.SavedHomes.Composer {
    public class SavedHomesUIComposer {
        public static SavedHomesPage MakeSavedHomesUI() {

            var dataTemplateSelector = new PropertyListingDataTemplateSelector();

            return new SavedHomesPage(dataTemplateSelector);
        }
    }
}
