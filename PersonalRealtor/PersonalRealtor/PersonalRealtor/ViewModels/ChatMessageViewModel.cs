using System;

using Xamarin.Forms;

namespace PersonalRealtor.ViewModels {
    public class ChatMessageViewModel : ContentPage {
        public ChatMessageViewModel() {
            Content = new StackLayout {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

