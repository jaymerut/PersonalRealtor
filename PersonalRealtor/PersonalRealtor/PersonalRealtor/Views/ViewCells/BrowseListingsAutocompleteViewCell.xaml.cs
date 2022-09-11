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
    public partial class BrowseListingsAutocompleteViewCell : ViewCell {

        private BrowseListingsAutocompleteViewModel ViewModel;

        public BrowseListingsAutocompleteViewCell() {
            InitializeComponent();

            BindingContext = this;
            SetupBrowseListingsAutocompleteViewCell();
        }

        private void SetupBrowseListingsAutocompleteViewCell() {

            // BindingContext
            this.BindingContextChanged += (s, e) => {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs) {
            this.ViewModel = (BrowseListingsAutocompleteViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                EntryAutocomplete.Text = this.ViewModel.Text;
        }
    }
}
