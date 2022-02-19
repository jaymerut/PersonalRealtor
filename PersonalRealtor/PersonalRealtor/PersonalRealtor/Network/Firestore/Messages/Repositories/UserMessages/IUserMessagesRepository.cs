using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Messages.Models;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.UserMessages {
    public interface IUserMessagesRepository {
        Task<Message> GetOneAsync(string userID, string messageID);
        Task<IEnumerable<Message>> GetAllAsync(string userID);
        void SendToRealtor(Message message, string authorID);
    }
}
