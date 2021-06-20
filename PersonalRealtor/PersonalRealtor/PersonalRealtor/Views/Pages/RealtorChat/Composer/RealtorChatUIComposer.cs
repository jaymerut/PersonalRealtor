using System;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Components.DataTemplateSelectors;

namespace PersonalRealtor.Views.Pages.RealtorChat.Composer {
    public class RealtorChatUIComposer {
        public static RealtorChatPage MakeRealtorChatUI() {

            var dataTemplateSelector = new RealtorChatDataTemplateSelector();

            return new RealtorChatPage(dataTemplateSelector);
        }
    }
}
