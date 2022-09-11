using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Models;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.Pages.Details.Composer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.BrowseListings.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseListingsPage : ContentPage
    {
        #region - Variables
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        #endregion

        #region - Constructors
        public BrowseListingsPage(DataTemplateSelector dataTemplateSelector)
        {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;

            InitializeComponent();

            SetUpBrowseListingsPage();
        }
        #endregion

        #region - Private Methods
        private void SetUpBrowseListingsPage() {
            if (Objects.Count == 0) {
                Objects.Add(new BrowseListingsAutocompleteViewModel());
                ActivityIndicatorListView.IsVisible = false;
            }
            BrowseListingsListView.ItemsSource = Objects;
            BrowseListingsListView.ItemTemplate = this.DataTemplateSelector;
        }

        private void BrowseListingsListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                if (e.SelectedItem is PropertyListing) {
                    NavigateToDetails(e.SelectedItem as PropertyListing);
                }
            }
        }
        private void NavigateToDetails(PropertyListing listing) {
            _ = Navigation.PushAsync(DetailsUIComposer.MakeDetailsUI(listing.PropertyId));

            BrowseListingsListView.SelectedItem = null;
        }
        #endregion

        #region - Public API
        #endregion
    }
}