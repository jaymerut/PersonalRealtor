using System;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Components.DataTemplateSelectors;
using Xamarin.Forms;
using PersonalRealtor.Network.Firestore.Messages.Models;
using PersonalRealtor.Network.Firestore.Messages.Repositories.RealtorMessages;
using PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalRealtor.Views.Pages.RealtorChat.Composer {
    public class RealtorChatUIComposer {
        public static RealtorChatPage MakeRealtorChatUI() {
            var dataTemplateSelector = new RealtorChatDataTemplateSelector();
            var service = new RealtorChatService(new UserMessagesRepository(), new RealtorMessagesRepository());

            return new RealtorChatPage(dataTemplateSelector, service);
        }

    }

    public interface IRealtorChatService {
        public Task<IEnumerable<Message>> GetUserMessages(string userID);
        public Task<IEnumerable<Message>> GetRealtorMessages(string userID);
        public void SendToUser(Message message, string participantID);
        public void SendToRealtor(Message message, string authorID);
    }

    public class RealtorChatService : IRealtorChatService {

        private UserMessagesRepositoryAdapter UserMessagesRepository;
        private RealtorMessagesRepositoryAdapter RealtorMessagesRepository;

        public RealtorChatService(IUserMessagesRepository userMessagesRepository, IRealtorMessagesRepository realtorMessagesRepository) {
            UserMessagesRepository = new UserMessagesRepositoryAdapter(userMessagesRepository);
            RealtorMessagesRepository = new RealtorMessagesRepositoryAdapter(realtorMessagesRepository);
        }

        public async Task<IEnumerable<Message>> GetUserMessages(string userID) {
            return await UserMessagesRepository.GetMessages(userID);
        }

        public async Task<IEnumerable<Message>> GetRealtorMessages(string userID) {
            return await RealtorMessagesRepository.GetMessages(userID);
        }

        public void SendToUser(Message message, string participantID) {
            RealtorMessagesRepository.SendToUser(message, participantID);
        }

        public void SendToRealtor(Message message, string authorID) {
            UserMessagesRepository.SendToRealtor(message, authorID);
        }
    }

    public class UserMessagesRepositoryAdapter {

        private IUserMessagesRepository Repository;

        public UserMessagesRepositoryAdapter(IUserMessagesRepository repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<Message>> GetMessages(string userID) {
            return await Repository.GetAllAsync(userID);
        }

        public void SendToRealtor(Message message, string authorID) {
            Repository.SendToRealtor(message, authorID);
        }
    }

    public class RealtorMessagesRepositoryAdapter {

        private IRealtorMessagesRepository Repository;

        public RealtorMessagesRepositoryAdapter(IRealtorMessagesRepository repository) {
            Repository = repository;
        }

        public async Task<IEnumerable<Message>> GetMessages(string userID) {
            return await Repository.GetAllAsync(userID);
        }

        public void SendToUser(Message message, string participantID) {
            Repository.SendToUser(message, participantID);
        }
    }
}
