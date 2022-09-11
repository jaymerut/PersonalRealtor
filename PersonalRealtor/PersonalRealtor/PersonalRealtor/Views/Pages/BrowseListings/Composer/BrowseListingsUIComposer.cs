using System;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Views.Pages.BrowseListings.UI;

namespace PersonalRealtor.Views.Pages.BrowseListings.Composer {
    public static class BrowseListingsUIComposer {
        public static BrowseListingsPage MakeBrowseListingsUI() {

            var dataTemplateSelector = new BrowseListingsDataTemplateSelector();

            return new BrowseListingsPage(dataTemplateSelector);
        }

    }
}
