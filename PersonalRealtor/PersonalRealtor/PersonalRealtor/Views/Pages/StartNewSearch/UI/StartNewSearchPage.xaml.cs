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
        private AutocompleteLocationViewModel CurrentLocationSelected;
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

            var groupList = result.Autocomplete.GroupBy(x => x.AreaType).Select(g => new AutocompleteLocationGroup() {
                GroupName = g.Key,
                Values = g.Select(v => v).ToList()
            }).ToList();

            Objects.Clear();

            foreach (var group in groupList) {
                var groupName = "";
                if (group.GroupName == "city" || group.GroupName == "postal_code") {
                    if (group.GroupName == "city") {
                        groupName = "CITY";
                    } else if (group.GroupName == "postal_code") {
                        groupName = "POSTAL CODE";
                    }
                    Objects.Add(new AutocompleteLocationGroupNameViewModel() {
                        Text = groupName
                    });
                }
                foreach (var location in group.Values) {
                    if (!String.IsNullOrEmpty(groupName)) {
                        var locationText = $"{location.City}, {location.StateCode}";
                        if (!String.IsNullOrEmpty(location.PostalCode)) {
                            locationText = $"{location.PostalCode}, {locationText}";
                        }
                        var viewModel = new AutocompleteLocationViewModel() {
                            Text = locationText,
                            City = location.City,
                            StateCode = location.StateCode,
                            PostalCode = location.PostalCode
                        };
                        if (CurrentLocationSelected == null) { CurrentLocationSelected = viewModel; }
                        Objects.Add(viewModel);
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
            CurrentLocationSelected = null;
            if (e.NewTextValue.Length > 2) {
                _ = RetrieveAutocompleteLocationsAsync(e.NewTextValue);
                AutocompleteFrame.IsVisible = true;
                ButtonSearch.IsVisible = true;
            } else {
                Objects.Clear();
                AutocompleteFrame.IsVisible = false;
                ButtonSearch.IsVisible = false;
            }
        }

        private void AutocompleteListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                if (e.SelectedItem is AutocompleteLocationViewModel) {
                    EntryAutocomplete.Text = ((AutocompleteLocationViewModel)e.SelectedItem).Text;
                    CurrentLocationSelected = (AutocompleteLocationViewModel)e.SelectedItem;
                    Objects.Clear();
                    AutocompleteFrame.IsVisible = false;
                }
            }
        }

        public void ButtonSearch_Clicked(System.Object sender, System.EventArgs e) {
            // TODO
        }
    }
}
