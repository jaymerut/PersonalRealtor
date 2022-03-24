using System;
using Xamarin.Forms;

namespace PersonalRealtor.ViewModels {
    public class ConversationViewModel {
        public string Title { get; set; }
        public string PlayerId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Action<string> OnHideConvo { get; set; }
    }
}
