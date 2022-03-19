using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Services.Delegates;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.Pages.RealtorChat.Composer;
using PersonalRealtor.Views.Pages.RealtorChatList.Composer;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.RealtorChatList.UI {
    public partial class RealtorChatListPage : ContentPage {
        #region - Variables
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private IRealtorChatListService Service;
        #endregion

        #region - Constructors
        public RealtorChatListPage(DataTemplateSelector dataTemplateSelector, IRealtorChatListService service) {
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            this.Service = service;

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
            RealtorChatListView.ItemTemplate = this.DataTemplateSelector;

            // Data
            PopulateList();            

            this.ActivityIndicatorListView.IsVisible = false;
        }

        // Data Logic
        private async void PopulateList() {
            await GetConversationNames();
            RealtorChatListView.ItemsSource = Objects;
        }

        private async Task GetConversationNames() {
            var conversations = (await Task.Run(() => Service.GetAllMessageConversationsAsync())).ToList();

            foreach (var convo in conversations) {
                var viewModel = new ConversationViewModel();
                viewModel.Title = convo.Id;
                viewModel.PlayerId = convo.PlayerId;

                this.Objects.Add(viewModel);
            }
        }

        private void RealtorChatListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                NavigateToRealtorChat(e.SelectedItem as ConversationViewModel);
            }
        }

        private void NavigateToRealtorChat(ConversationViewModel viewModel) {
            _ = Navigation.PushAsync(RealtorChatUIComposer.MakeRealtorChatUI(viewModel.Title, viewModel.PlayerId));

            RealtorChatListView.SelectedItem = null;
        }
        #endregion

        #region - Public API
        #endregion
    }
}
