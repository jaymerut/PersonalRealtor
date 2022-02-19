using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

            //Service.SendToRealtor(new Message() { MessageID = "1111", AuthorID = "9999", ParticipantID = "909", Content = "Does this work?", Timestamp = "test" }, "9999");
            
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
            GetMessages();
        }

        private async void GetMessages() {
            var messages = (await Task.Run(() => Service.GetUserMessages("User100"))).ToList();
            Console.WriteLine("");
        }
        #endregion

        #region - Public API
        #endregion
    }
}