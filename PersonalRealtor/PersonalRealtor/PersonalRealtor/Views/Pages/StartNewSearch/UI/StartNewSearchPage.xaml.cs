using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RapidAPI.API;
using PersonalRealtor.Network.RapidAPI.Models;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.StartNewSearch.UI {
    public partial class StartNewSearchPage : ContentPage {

        private RapidAPI RapidAPI = new RapidAPI();
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private LocationsAutoCompleteResponse Response;
        public int SelectedSegment;

        public StartNewSearchPage(DataTemplateSelector dataTemplateSelector) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;

            InitializeComponent();

            SetupStartNewSearchPage();
        }

        private void SetupStartNewSearchPage() {
            this.ButtonSearch.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSearch.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);

            AutocompleteListView.ItemsSource = Objects;
            AutocompleteListView.ItemTemplate = this.DataTemplateSelector;
            SelectedSegment = 0;
        }

        private async Task RetrieveAutocompleteLocationsAsync(String text) {
            var result = await RapidAPI.GetLocationsAutoComplete(new LocationsAutoCompleteRequest() {
                Input = text
            });

            this.Response = result;

            var groupList = result.Autocomplete.GroupBy(x => x.AreaType).Select(g => new AutocompleteLocationGroup() {
                GroupName = g.Key,
                Values = g.Select(v => v).ToList()
            }).ToList();

            Objects.Clear();

            foreach (var group in groupList) {
                if (group.GroupName == "city" || group.GroupName == "postal_code") {

                }
                foreach (var location in group.Values) {
                    if (group.GroupName == "city" || group.GroupName == "postal_code") {
                        var locationText = $"{location.City}, {location.StateCode}";
                        if (!String.IsNullOrEmpty(location.PostalCode)) {
                            locationText = $"{location.PostalCode}, {locationText}";
                        }
                        Objects.Add(new AutocompleteLocationViewModel() {
                            Text = locationText,
                            City = location.City,
                            StateCode = location.StateCode,
                            PostalCode = location.PostalCode
                        });
                    }
                }
            }
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

        void Entry_TextChanged(object sender, TextChangedEventArgs e) {
            if (e.NewTextValue.Length > 2) {
                _ = RetrieveAutocompleteLocationsAsync(e.NewTextValue);
            } else {
                Objects.Clear();
            }
        }

        private void AutocompleteListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                // TODO
            }
        }

        public void ButtonSearch_Clicked(System.Object sender, System.EventArgs e) {
            // TODO
        }
    }
}
