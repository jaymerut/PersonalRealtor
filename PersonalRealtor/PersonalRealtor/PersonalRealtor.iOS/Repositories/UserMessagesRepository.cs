using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.iOS.Extensions;
using PersonalRealtor.iOS.Services;
using PersonalRealtor.Network.Firestore.Messages;
using PersonalRealtor.Network.Firestore.Messages.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(PersonalRealtor.iOS.Repositories.UserMessagesRepository))]
namespace PersonalRealtor.iOS.Repositories {
    public class UserMessagesRepository : IUserMessagesRepository<Message> {
        public IEnumerable<Message> GetAll(string userID) {
            return this.GetAllAsync(userID).Result;
        }

        public Task<IEnumerable<Message>> GetAllAsync(string userID) {
            return FirestoreService.Instance
                                   .GetCollection("UserMessages")
                                   .GetDocument(userID)
                                   .GetCollection("Messages")
                                   .GetCollectionAsync<Message>();
        }

        public Message GetOne(string userID, string messageID) {
            return this.GetOneAsync(userID, messageID).Result;
        }

        public Task<Message> GetOneAsync(string userID, string messageID) {
            return FirestoreService.Instance
                                   .GetCollection("UserMessages")
                                   .GetDocument(userID)
                                   .GetCollection("Messages")
                                   .GetDocument(messageID)
                                   .GetDocumentAsync<Message>();
        }
    }
}
