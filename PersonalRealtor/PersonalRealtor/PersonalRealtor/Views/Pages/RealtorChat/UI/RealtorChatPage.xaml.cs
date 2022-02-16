using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Models;
using PersonalRealtor.Network.Firestore.Repositories;
using PersonalRealtor.Services.Delegates;
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
        private IConversationResourceService ConversationResourceService;
        #endregion

        #region - Constructors
        public RealtorChatPage(DataTemplateSelector dataTemplateSelector, IConversationResourceService service) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            this.ConversationResourceService = service;

            InitializeComponent();

            SetUpRealtorChatPage();

            TestFirestoreAsync();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing() {
            base.OnAppearing();

        }
        #endregion

        #region - Private Methods
        private async void TestFirestoreAsync() {
            var collections = await DependencyService.Get<IRepository<User>>().GetAllAsync();
            Console.WriteLine("Collections retrieved");
        }
        private void SetUpRealtorChatPage() {
            // Data
            _ = RetrieveConversationsAsync();

            RealtorChatListView.ItemsSource = Objects;
            RealtorChatListView.ItemTemplate = this.DataTemplateSelector;

            this.ActivityIndicatorListView.IsVisible = false;

            this.ButtonSend.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSend.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
        }

        // Data Logic
        private async Task RetrieveConversationsAsync() {
            var conversations = this.ConversationResourceService.RetrieveConversations();

        }

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