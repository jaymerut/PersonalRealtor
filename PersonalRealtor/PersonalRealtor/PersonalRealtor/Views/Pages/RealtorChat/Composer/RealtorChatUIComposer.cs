using System;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Components.DataTemplateSelectors;
using Xamarin.Forms;
using PersonalRealtor.Network.Firestore.Messages.Models;
using PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalRealtor.Views.Pages.RealtorChat.Composer {
    public class RealtorChatUIComposer {
        public static RealtorChatPage MakeRealtorChatUI(string username, string playerId) {
            var dataTemplateSelector = new RealtorChatDataTemplateSelector();
            var service = new RealtorChatService(new UserMessagesRepository());

            return new RealtorChatPage(dataTemplateSelector, service, username, playerId);
        }

    }

    public interface IRealtorChatService {
        public Task<IEnumerable<Message>> GetMessagesForUser(string playerID);
        public Task<Message> GetOneMessage(string playerID, string messageID);
        public void SendMessage(Message message, string username);
    }

    public class RealtorChatService : IRealtorChatService {

        private UserMessagesRepositoryAdapter UserMessagesRepository;

        public RealtorChatService(IUserMessagesRepository userMessagesRepository) {
            UserMessagesRepository = new UserMessagesRepositoryAdapter(userMessagesRepository);
        }

        public async Task<IEnumerable<Message>> GetMessagesForUser(string playerID) {
            return await UserMessagesRepository.GetAllMessagesForUser(playerID);
        }

        public async Task<Message> GetOneMessage(string playerID, string messageID) {
            return await UserMessagesRepository.GetOneMessage(playerID, messageID);
        }

        public void SendMessage(Message message, string username) {
            UserMessagesRepository.SendMessage(message, username);
        }

    }

    public class UserMessagesRepositoryAdapter {

        private IUserMessagesRepository Repository;

        public UserMessagesRepositoryAdapter(IUserMessagesRepository repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesForUser(string playerID) {
            return await Repository.GetAllMessagesForUserAsync(playerID);
        }

        public async Task<Message> GetOneMessage(string playerID, string messageID) {
            return await Repository.GetOneMessageAsync(playerID, messageID);
        }

        public void SendMessage(Message message, string username) {
            Repository.SendMessage(message, username);
        }
    }

}
