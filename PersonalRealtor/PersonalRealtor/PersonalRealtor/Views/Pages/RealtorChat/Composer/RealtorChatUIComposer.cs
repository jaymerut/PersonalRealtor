using System;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Components.DataTemplateSelectors;
using Xamarin.Forms;
using PersonalRealtor.Network.Firestore.Users.Models;
using PersonalRealtor.Network.Firestore.Users;
using PersonalRealtor.Network.Firestore.Messages;
using PersonalRealtor.Network.Firestore.Messages.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalRealtor.Views.Pages.RealtorChat.Composer {
    public class RealtorChatUIComposer {
        public static RealtorChatPage MakeRealtorChatUI() {

            var dataTemplateSelector = new RealtorChatDataTemplateSelector();
            var service = new RealtorChatService();

            return new RealtorChatPage(dataTemplateSelector, service);
        }

    }

    public interface IRealtorChatService {
        public User GetUser(string id);
        public List<Message> GetUserMessages(string userID);
        public List<Message> GetRealtorMessages(string userID);
    }

    public class RealtorChatService : IRealtorChatService {

        private UsersRepositoryAdapter UsersRepository;
        private UserMessagesRepositoryAdapter UserMessagesRepository;
        private RealtorMessagesRepositoryAdapter RealtorMessagesRepository;

        public RealtorChatService() {
            UsersRepository = new UsersRepositoryAdapter();
            UserMessagesRepository = new UserMessagesRepositoryAdapter();
            RealtorMessagesRepository = new RealtorMessagesRepositoryAdapter();
        }

        public User GetUser(string id) {
            return UsersRepository.GetUser(id);
        }

        public List<Message> GetUserMessages(string userID) {
            return UserMessagesRepository.GetMessages(userID);
        }

        public List<Message> GetRealtorMessages(string userID) {
            return RealtorMessagesRepository.GetMessages(userID);
        }
    }

    public class UsersRepositoryAdapter {

        private IUsersRepository<User> Repository;

        public UsersRepositoryAdapter() {
            Repository = DependencyService.Get<IUsersRepository<User>>();
        }

        public User GetUser(string id) {
            return Repository.GetOne(id);
        }
    }

    public class UserMessagesRepositoryAdapter {

        private IUserMessagesRepository<Message> Repository;

        public UserMessagesRepositoryAdapter() {
            Repository = DependencyService.Get<IUserMessagesRepository<Message>>();
        }

        public List<Message> GetMessages(string userID) {
            return Repository.GetAll(userID).ToList();
        }
    }

    public class RealtorMessagesRepositoryAdapter {

        private IRealtorMessagesRepository<Message> Repository;

        public RealtorMessagesRepositoryAdapter() {
            Repository = DependencyService.Get<IRealtorMessagesRepository<Message>>();
        }

        public List<Message> GetMessages(string userID) {
            return Repository.GetAll(userID).ToList();
        }
    }
}
