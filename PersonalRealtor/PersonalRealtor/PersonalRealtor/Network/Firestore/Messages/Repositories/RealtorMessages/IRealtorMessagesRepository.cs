using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.Messages.Models;

namespace PersonalRealtor.Network.Firestore.Messages.Repositories.RealtorMessages {
    public interface IRealtorMessagesRepository {
        Task<Message> GetOneAsync(string userID, string messageID);
        Task<IEnumerable<Message>> GetAllAsync(string userID);
        void SendToUser(Message message, string participantID);
    }
}
