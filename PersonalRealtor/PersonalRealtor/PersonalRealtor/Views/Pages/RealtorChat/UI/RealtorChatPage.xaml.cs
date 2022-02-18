using System;
using System.Collections.ObjectModel;
using PersonalRealtor.Views.Pages.RealtorChat.Composer;
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
        private IRealtorChatService Service;
        #endregion

        #region - Constructors
        public RealtorChatPage(DataTemplateSelector dataTemplateSelector, IRealtorChatService service) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            this.Service = service;

            InitializeComponent();

            SetUpRealtorChatPage();

        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing() {
            base.OnAppearing();

        }
        #endregion

        #region - Private Methods
        private void SetUpRealtorChatPage() {

            RealtorChatListView.ItemsSource = Objects;
            RealtorChatListView.ItemTemplate = this.DataTemplateSelector;

            this.ActivityIndicatorListView.IsVisible = false;

            this.ButtonSend.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSend.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
        }

        // Data Logic
        

        private void RealtorChatListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                // TODO: Anything to happen if a user selects a message?
            }
        }

        // UIResponders
        public async void ButtonSend_Clicked(System.Object sender, System.EventArgs e) {
            
        }
        #endregion

        #region - Public API
        #endregion
    }
}