using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Components.DataTemplateSelectors;
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
        public Task<IEnumerable<string>> GetAllConversationNamesAsync();
    }

    public class RealtorChatService : IRealtorChatListService {

        private UserMessagesRepositoryAdapter UserMessagesRepository;

        public RealtorChatService(IUserMessagesRepository userMessagesRepository) {
            UserMessagesRepository = new UserMessagesRepositoryAdapter(userMessagesRepository);
        }

        public async Task<IEnumerable<string>> GetAllConversationNamesAsync() {
            return await UserMessagesRepository.GetAllConversationNames();
        }

    }

    public class UserMessagesRepositoryAdapter {

        private IUserMessagesRepository Repository;

        public UserMessagesRepositoryAdapter(IUserMessagesRepository repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<string>> GetAllConversationNames() {
            return await Repository.GetAllConversationNamesAsync();
        }

    }
}
