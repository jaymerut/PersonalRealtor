using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Messages.Models;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages {
    public interface IUserMessagesRepository {
        Task<IEnumerable<string>> GetAllConversationNamesAsync();
        Task<IEnumerable<Message>> GetAllMessagesForUserAsync(string userID);
        Task<Message> GetOneMessageAsync(string userID, string messageID);
        void SendMessage(Message message, string userID);
    }
}
