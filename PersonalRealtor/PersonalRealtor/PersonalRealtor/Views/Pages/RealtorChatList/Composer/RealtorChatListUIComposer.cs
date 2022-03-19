using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Network.Firestore.Messages.Models;
using PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages;
using PersonalRealtor.Services;
using PersonalRealtor.Views.Pages.RealtorChatList.UI;

namespace PersonalRealtor.Views.Pages.RealtorChatList.Composer {
    public class RealtorChatListUIComposer {
        public static RealtorChatListPage MakeRealtorChatListUI() {

            var dataTemplateSelector = new RealtorChatListDataTemplateSelector();
            var service = new RealtorChatService(new UserMessagesRepository());

            return new RealtorChatListPage(dataTemplateSelector, service);
        }
    }

    public interface IRealtorChatListService {
        public Task<IEnumerable<MessageDocument>> GetAllMessageConversationsAsync();
    }

    public class RealtorChatService : IRealtorChatListService {

        private UserMessagesRepositoryAdapter UserMessagesRepository;

        public RealtorChatService(IUserMessagesRepository userMessagesRepository) {
            UserMessagesRepository = new UserMessagesRepositoryAdapter(userMessagesRepository);
        }

        public async Task<IEnumerable<MessageDocument>> GetAllMessageConversationsAsync() {
            return await UserMessagesRepository.GetAllMessageConversations();
        }

    }

    public class UserMessagesRepositoryAdapter {

        private IUserMessagesRepository Repository;

        public UserMessagesRepositoryAdapter(IUserMessagesRepository repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<MessageDocument>> GetAllMessageConversations() {
            return await Repository.GetAllMessageConversationsAsync();
        }

    }
}
