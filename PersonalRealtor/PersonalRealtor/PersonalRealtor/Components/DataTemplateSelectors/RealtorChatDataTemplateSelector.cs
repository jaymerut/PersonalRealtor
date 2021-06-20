using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors {
    public class RealtorChatDataTemplateSelector : DataTemplateSelector {
        public DataTemplate DataTemplateChatMessage { get; set; }

        public RealtorChatDataTemplateSelector() {
            DataTemplateChatMessage = new DataTemplate(typeof(ChatMessageViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is ChatMessageViewModel) {
                return DataTemplateChatMessage;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
