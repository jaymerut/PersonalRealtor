using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Components.Helpers;
using PersonalRealtor.Models;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.Pages.Details.Composer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.SavedHomes.UI {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedHomesPage : ContentPage {
        #region - Variables
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private BookmarkHelper BookmarkHelper;
        #endregion

        #region - Constructors
        public SavedHomesPage(DataTemplateSelector dataTemplateSelector) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            this.BookmarkHelper = new BookmarkHelper();

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

            this.ActivityIndicatorListView.IsVisible = false;
        }

        // Data Logic
        private void RetrieveListings() {
            foreach (var savedHome in BookmarkHelper.RetrieveSavedHomes().SavedPropertyHomes) {
                this.Objects.Add(savedHome);
            }
        }

        private void SavedHomesListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                NavigateToDetails(e.SelectedItem as SavedHome);
            }
        }

        private void NavigateToDetails(SavedHome savedHome) {
            _ = Navigation.PushAsync(DetailsUIComposer.MakeDetailsUI(savedHome.PropertyId));

            SavedHomesListView.SelectedItem = null;
        }
        #endregion

        #region - Public API
        #endregion
    }
}