using System;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Services;
using PersonalRealtor.Views.Pages.RealtorChatList.UI;

namespace PersonalRealtor.Views.Pages.RealtorChatList.Composer {
    public class RealtorChatListUIComposer {
        public static RealtorChatListPage MakeRealtorChatListUI() {

            var dataTemplateSelector = new RealtorChatListDataTemplateSelector();
            var service = new ConversationResourceService();

            return new RealtorChatListPage(dataTemplateSelector, service);
        }
    }
}
