using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PersonalRealtor.Services.Delegates;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.RealtorChatList.UI {
    public partial class RealtorChatListPage : ContentPage {
        #region - Variables
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private IConversationResourceService ConversationResourceService;
        #endregion

        #region - Constructors
        public RealtorChatListPage(DataTemplateSelector dataTemplateSelector, IConversationResourceService service) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            this.ConversationResourceService = service;

            InitializeComponent();

            SetUpRealtorChatListPage();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing() {
            base.OnAppearing();

        }
        #endregion

        #region - PriNavvate Methods
        private void SetUpRealtorChatListPage() {
            // Data
            _ = RetrieveConversationsAsync();

            RealtorChatListView.ItemsSource = Objects;
            RealtorChatListView.ItemTemplate = this.DataTemplateSelector;

            this.ActivityIndicatorListView.IsVisible = false;
        }

        // Data Logic
        private async Task RetrieveConversationsAsync() {
            this.Objects.Clear();
            var conversations = this.ConversationResourceService.RetrieveConversations();
            foreach (var convo in conversations) {
                var viewModel = new ConversationViewModel();
                viewModel.Title = convo.FriendlyName;
                viewModel.DateUpdated = convo.DateUpdated;

                this.Objects.Add(viewModel);
            }
        }

        private void RealtorChatListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                // TODO: Anything to happen if a user selects a message?
            }
        }
        #endregion

        #region - Public API
        #endregion
    }
}
