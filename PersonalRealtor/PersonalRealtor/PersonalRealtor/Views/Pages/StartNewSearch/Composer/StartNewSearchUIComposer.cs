using System;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Views.Pages.StartNewSearch.UI;

namespace PersonalRealtor.Views.Pages.StartNewSearch.Composer {
    public static class StartNewSearchUIComposer {
        public static StartNewSearchPage MakeStartNewSearchUI() {

            var dataTemplateSelector = new StartNewSearchDataTemplateSelector();

            return new StartNewSearchPage(dataTemplateSelector);
        }

    }
}
