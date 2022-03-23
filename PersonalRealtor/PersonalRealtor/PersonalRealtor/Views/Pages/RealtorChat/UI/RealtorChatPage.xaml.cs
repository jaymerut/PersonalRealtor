using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Com.OneSignal;
using MonkeyCache.FileStore;
using PersonalRealtor.Cache.AdminLogin;
using PersonalRealtor.Cache.Username;
using PersonalRealtor.Components.Helpers;
using PersonalRealtor.Network.Firestore.Messages.Models;
using PersonalRealtor.ViewModels;
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
        private string UserID;
        private string PlayerId;
        private bool IsAdmin;
        #endregion

        #region - Constructors
        public RealtorChatPage(DataTemplateSelector dataTemplateSelector, IRealtorChatService service, string userID, string playerId) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            this.Service = service;
            this.UserID = userID;
            this.PlayerId = playerId;
            this.IsAdmin = AdminLoginCache.IsAdminLoggedIn();

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

            RealtorChatListView.ItemTemplate = this.DataTemplateSelector;
            PopulateList();

            this.ActivityIndicatorListView.IsVisible = false;

            this.ButtonSend.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSend.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);

            
        }

        // Data Logic
        private async void PopulateList() {
            await GetMessages();
            RealtorChatListView.ItemsSource = Objects;
            RealtorChatListView.ScrollTo(Objects[Objects.Count - 1], ScrollToPosition.End, false);
        }
        

        private void RealtorChatListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                RealtorChatListView.SelectedItem = null;
            }
        }

        // UIResponders
        public async void ButtonSend_Clicked(System.Object sender, System.EventArgs e) {
            SendMessage();
        }

        private async Task GetMessages() {
            var messages = (await Task.Run(() => Service.GetMessagesForUser(this.UserID))).ToList();
            messages.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.Timestamp), DateTime.Parse(y.Timestamp)));
            foreach (var message in messages) {
                Objects.Add(ConvertMessageToViewModel(message));
            }
        }

        private void AddMessageToList(Message message) {
            Objects.Add(ConvertMessageToViewModel(message));

            RealtorChatListView.ScrollTo(Objects[Objects.Count - 1], ScrollToPosition.End, true);
        }

        private void SendMessage() {
            if (!string.IsNullOrEmpty(EditorMessage.Text.Trim())) {
                var message = new Message() {
                    MessageID = RandomHelper.RandomString(20),
                    AuthorID = IsAdmin ? RealtorSingleton.Instance.UserName : UsernameCache.GetCurrentUsername(),
                    ParticipantID = IsAdmin ? this.UserID : RealtorSingleton.Instance.UserName,
                    Content = EditorMessage.Text,
                    Timestamp = DateTime.Now.ToString("MM/dd/yy hh:mm tt")
                };
                Service.SendMessage(message, this.UserID);
                SendNotification(message.Content);
                AddMessageToList(message);
                EditorMessage.Text = "";
            }
        }

        private ChatMessageViewModel ConvertMessageToViewModel(Message message) {
            bool isAuthor;
            if (IsAdmin) {
                isAuthor = message?.AuthorID?.Equals(RealtorSingleton.Instance.UserName) ?? false;
            } else {
                isAuthor = message?.AuthorID?.Equals(UsernameCache.GetCurrentUsername()) ?? false;
            }

            return new ChatMessageViewModel() {
                Text = message.Content,
                Timestamp = message.Timestamp,
                HorizontalLayoutOptions = isAuthor ? LayoutOptions.Start : LayoutOptions.End,
                BackgroundColor = isAuthor ? Color.FromHex(RealtorSingleton.Instance.PrimaryColor) : Color.LightGray,
                TextColor = isAuthor ? Color.White : Color.Black
            };
        }

        private void SendNotification(string message) {
            var notification = new Dictionary<string, object>();

            notification["headings"] = new Dictionary<string, string>() { { "en", "New Message!" } };
            notification["contents"] = new Dictionary<string, string>() { { "en", message } };
            notification["include_player_ids"] = new List<string>() { this.PlayerId };

            OneSignal.Current.PostNotification(notification);
        }
        #endregion

        #region - Public API
        #endregion
    }
}