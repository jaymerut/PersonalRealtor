using System;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Services;

namespace PersonalRealtor.Views.Pages.RealtorChat.Composer {
    public class RealtorChatUIComposer {
        public static RealtorChatPage MakeRealtorChatUI() {

            var dataTemplateSelector = new RealtorChatDataTemplateSelector();
            var service = new ConversationResourceService();

            return new RealtorChatPage(dataTemplateSelector, service);
        }
    }
}
