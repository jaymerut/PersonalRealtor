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
        public static RealtorChatPage MakeRealtorChatUI(string userID, string playerId) {
            var dataTemplateSelector = new RealtorChatDataTemplateSelector();
            var service = new RealtorChatService(new UserMessagesRepository());

            return new RealtorChatPage(dataTemplateSelector, service, userID, playerId);
        }

    }

    public interface IRealtorChatService {
        public Task<IEnumerable<Message>> GetMessagesForUser(string userID);
        public Task<Message> GetOneMessage(string userID, string messageID);
        public void SendMessage(Message message, string userID);
    }

    public class RealtorChatService : IRealtorChatService {

        private UserMessagesRepositoryAdapter UserMessagesRepository;

        public RealtorChatService(IUserMessagesRepository userMessagesRepository) {
            UserMessagesRepository = new UserMessagesRepositoryAdapter(userMessagesRepository);
        }

        public async Task<IEnumerable<Message>> GetMessagesForUser(string userID) {
            return await UserMessagesRepository.GetAllMessagesForUser(userID);
        }

        public async Task<Message> GetOneMessage(string userID, string messageID) {
            return await UserMessagesRepository.GetOneMessage(userID, messageID);
        }

        public void SendMessage(Message message, string userID) {
            UserMessagesRepository.SendMessage(message, userID);
        }

    }

    public class UserMessagesRepositoryAdapter {

        private IUserMessagesRepository Repository;

        public UserMessagesRepositoryAdapter(IUserMessagesRepository repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesForUser(string userID) {
            return await Repository.GetAllMessagesForUserAsync(userID);
        }

        public async Task<Message> GetOneMessage(string userID, string messageID) {
            return await Repository.GetOneMessageAsync(userID, messageID);
        }

        public void SendMessage(Message message, string userID) {
            Repository.SendMessage(message, userID);
        }
    }

}
