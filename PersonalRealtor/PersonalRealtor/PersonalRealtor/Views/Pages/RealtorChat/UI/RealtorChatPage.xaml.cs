using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.RealtorChat.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealtorChatPage : ContentPage
    {
        #region - Variables
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        #endregion

        #region - Constructors
        public RealtorChatPage(DataTemplateSelector dataTemplateSelector) {
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
            _ = RetrieveChatMessagesAsync();

            RealtorChatListView.ItemsSource = Objects;
            RealtorChatListView.ItemTemplate = this.DataTemplateSelector;

            this.ActivityIndicatorListView.IsVisible = false;
        }

        // Data Logic
        private async Task RetrieveChatMessagesAsync() {
            // TODO: Get Chat Messages Here
        }

        private void SavedHomesListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                // TODO: Anything to happen if a user selects a message?
            }
        }
        #endregion

        #region - Public API
        #endregion
    }
}