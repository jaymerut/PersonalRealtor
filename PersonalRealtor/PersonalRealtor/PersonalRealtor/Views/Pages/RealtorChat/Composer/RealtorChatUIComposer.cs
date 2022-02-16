using System;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Services;
using Xamarin.Forms;
using PersonalRealtor.Network.Firestore.Repositories;
using PersonalRealtor.Network.Firestore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

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
    }

    public class RealtorChatService : IRealtorChatService {

        private UserRepositoryAdapter UserRepository;
        public RealtorChatService() {
            UserRepository = new UserRepositoryAdapter();
        }

        public User GetUser(string id) {
            return UserRepository.GetUser(id);
        }
    }

    public class UserRepositoryAdapter {

        private IRepository<User> Repository;

        public UserRepositoryAdapter() {
            Repository = DependencyService.Get<IRepository<User>>();
        }

        public User GetUser(string id) {
            return Repository.GetOne(id);
        }
    }
}
