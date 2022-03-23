using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors {
    public class RealtorChatListDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DataTemplateConversation { get; set; }

        public RealtorChatListDataTemplateSelector() {
            DataTemplateConversation = new DataTemplate(typeof(ConversationViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is ConversationViewModel) {
                return DataTemplateConversation;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
