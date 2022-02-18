using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Droid.Extensions;
using PersonalRealtor.Droid.Services;
using PersonalRealtor.Network.Firestore.Messages;
using PersonalRealtor.Network.Firestore.Messages.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(PersonalRealtor.Droid.Repositories.UserMessagesRepository))]
namespace PersonalRealtor.Droid.Repositories {
    public class UserMessagesRepository : IUserMessagesRepository<Message> {
        public IEnumerable<Message> GetAll(string userID) {
            return this.GetAllAsync(userID).Result;
        }

        public Task<IEnumerable<Message>> GetAllAsync(string userID) {
            return FirestoreService.Instance
                                   .Collection("UserMessages")
                                   .Document(userID)
                                   .Collection("Messages")
                                   .GetCollectionAsync<Message>();
        }

        public Message GetOne(string userID, string messageID) {
            return this.GetOneAsync(userID, messageID).Result;
        }

        public Task<Message> GetOneAsync(string userID, string messageID) {
            return FirestoreService.Instance
                                   .Collection("UserMessages")
                                   .Document(userID)
                                   .Collection("Messages")
                                   .Document(messageID)
                                   .GetDocumentAsync<Message>();
        }
    }
}
