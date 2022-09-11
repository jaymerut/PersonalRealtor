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
        public int SelectedSegment;

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
        }

        private void SegmentedControl_OnSegmentSelected(System.Object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e) {
            var selectedOption = this.SegmentedControl.Children.ToList()[e.NewValue];
            switch (selectedOption.Text) {
                case "For Sale":
                    SelectedSegment = 0;
                    break;
                case "For Rent":
                    SelectedSegment = 1;
                    break;
                case "Sold":
                    SelectedSegment = 2;
                    break;
                default:
                    break;
            }
        }
    }
}
