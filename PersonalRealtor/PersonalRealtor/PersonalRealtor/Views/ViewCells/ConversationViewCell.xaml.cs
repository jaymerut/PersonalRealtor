using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationViewCell : ViewCell {
        public ConversationViewCell() {
            InitializeComponent();
        }

        private void SwipeItemView_Invoked(System.Object sender, System.EventArgs e) {
            ConversationViewModel viewModel = (ConversationViewModel)BindingContext;
            viewModel?.OnHideConvo(viewModel.PlayerId);
        }
    }
}
