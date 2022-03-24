using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Cache.OneSignal;
using PersonalRealtor.Network.Firestore.Messages.Models;
using Plugin.CloudFirestore;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages {
    public class UserMessagesRepository : IUserMessagesRepository {
        public UserMessagesRepository() {
        }

        public async Task<IEnumerable<MessageDocument>> GetAllMessageConversationsAsync() {
            var results = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .GetAsync().ConfigureAwait(true);
            return results.ToObjects<MessageDocument>();
        }
        public async Task<IEnumerable<Message>> GetAllMessagesForUserAsync(string playerID) {
            var results = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(playerID)
                .Collection("Messages")
                .GetAsync().ConfigureAwait(true);
            return results.ToObjects<Message>();
        }

        public async Task<Message> GetOneMessageAsync(string playerID, string messageID) {
            var result = await CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(playerID)
                .Collection("Messages")
                .Document(messageID).GetAsync().ConfigureAwait(true);
            return result.ToObject<Message>();
        }

        public void SendMessage(Message message, string username) {
            CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(OneSignalCache.GetPlayerID())
                .SetAsync(new MessageDocument(OneSignalCache.GetPlayerID(), username));

            CrossCloudFirestore.Current.Instance
                .Collection("UserMessages")
                .Document(OneSignalCache.GetPlayerID())
                .Collection("Messages")
                .Document(message.MessageID)
                .SetAsync(message);
        }
    }
}
