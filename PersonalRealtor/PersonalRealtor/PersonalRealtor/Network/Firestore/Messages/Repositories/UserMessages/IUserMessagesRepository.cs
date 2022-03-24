using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Messages.Models;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages {
    public interface IUserMessagesRepository {
        Task<IEnumerable<MessageDocument>> GetAllMessageConversationsAsync();
        Task<IEnumerable<Message>> GetAllMessagesForUserAsync(string playerID);
        Task<Message> GetOneMessageAsync(string playerID, string messageID);
        void SendMessage(Message message, string username);
    }
}
