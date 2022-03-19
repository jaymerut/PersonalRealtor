using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Messages.Models;
using Plugin.CloudFirestore;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages {
    public class UserMessagesRepository : IUserMessagesRepository {
        public UserMessagesRepository() {
        }

        public async Task<IEnumerable<string>> GetAllConversationNamesAsync() {
            var results = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .GetAsync().ConfigureAwait(true);
            return results.Documents.Select(x => x.Id);
        }
        public async Task<IEnumerable<Message>> GetAllMessagesForUserAsync(string userID) {
            var results = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(userID)
                .Collection("Messages")
                .GetAsync().ConfigureAwait(true);
            return results.ToObjects<Message>();
        }

        public async Task<Message> GetOneMessageAsync(string userID, string messageID) {
            var result = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(userID)
                .Collection("Messages")
                .Document(messageID).GetAsync().ConfigureAwait(true);
            return result.ToObject<Message>();
        }

        public void SendMessage(Message message, string userID) {
            CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(userID)
                .SetAsync(new MessageDocument() { Id = userID });

            CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(userID)
                .Collection("Messages")
                .Document(message.MessageID)
                .SetAsync(message);
        }
    }
}
