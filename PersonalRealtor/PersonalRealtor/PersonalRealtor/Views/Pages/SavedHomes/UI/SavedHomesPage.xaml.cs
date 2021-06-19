using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Models;
using PersonalRealtor.Views.Pages.Details.Composer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.SavedHomes.UI {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedHomesPage : ContentPage {
        #region - Variables
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        #endregion

        #region - Constructors
        public SavedHomesPage(DataTemplateSelector dataTemplateSelector) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;

            InitializeComponent();

            SetUpSavedHomesPage();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing() {
            base.OnAppearing();

        }
        #endregion

        #region - Private Methods
        private void SetUpSavedHomesPage() {
            // Data
            RetrieveListings();

            SavedHomesListView.ItemsSource = Objects;
            SavedHomesListView.ItemTemplate = this.DataTemplateSelector;

        }

        // Data Logic
        private void RetrieveListings() {

        }

        private void SavedHomesListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                NavigateToDetails(e.SelectedItem as PropertyListing);
            }
        }

        private void NavigateToDetails(PropertyListing listing) {
            _ = Navigation.PushAsync(DetailsUIComposer.MakeDetailsUI(listing.PropertyId));

            SavedHomesListView.SelectedItem = null;
        }
        #endregion

        #region - Public API
        #endregion
    }
}