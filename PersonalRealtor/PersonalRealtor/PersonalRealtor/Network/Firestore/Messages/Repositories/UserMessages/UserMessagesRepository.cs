using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Messages.Models;
using Plugin.CloudFirestore;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages {
    public class UserMessagesRepository : IUserMessagesRepository {
        public UserMessagesRepository() {
        }

        public async Task<IEnumerable<Message>> GetAllAsync(string userID) {
            var results = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document("userID")
                .Collection("Messages")
                .GetAsync().ConfigureAwait(true);
            return results.ToObjects<Message>();
        }

        public async Task<Message> GetOneAsync(string userID, string messageID) {
            var result = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(userID)
                .Collection("Messages")
                .Document(messageID).GetAsync().ConfigureAwait(true);
            return result.ToObject<Message>();
        }

        public void SendToRealtor(Message message, string authorID) {
            CrossCloudFirestore.Current.Instance
                .Collection("RealtorMessages")
                .Document(authorID)
                .Collection("Messages")
                .Document(message.MessageID)
                .SetAsync(message);

            CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(authorID)
                .Collection("Messages")
                .Document(message.MessageID)
                .SetAsync(message);
        }
    }
}
