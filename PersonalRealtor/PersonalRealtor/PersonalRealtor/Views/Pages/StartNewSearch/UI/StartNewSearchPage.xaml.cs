using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.StartNewSearch.UI {
    public partial class StartNewSearchPage : ContentPage {

        public int SelectedSegment;

        public StartNewSearchPage() {
            InitializeComponent();

            SetupStartNewSearchPage();
        }

        private void SetupStartNewSearchPage() {
            this.ButtonSearch.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSearch.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
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

        public void ButtonSearch_Clicked(System.Object sender, System.EventArgs e) {
            
        }
    }
}
