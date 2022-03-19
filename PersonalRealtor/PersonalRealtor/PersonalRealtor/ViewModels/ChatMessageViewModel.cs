using System;

using Xamarin.Forms;

namespace PersonalRealtor.ViewModels {
    public class ChatMessageViewModel {
        public string Text { get; set; }
        public string Timestamp { get; set; }
        public LayoutOptions HorizontalLayoutOptions { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
    }
}

