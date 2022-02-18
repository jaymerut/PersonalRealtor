using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalRealtor.Network.Firestore.Messages {
    public interface IRealtorMessagesRepository<T> {
        T GetOne(string userID, string messageID);
        Task<T> GetOneAsync(string userID, string messageID);

        IEnumerable<T> GetAll(string userID);
        Task<IEnumerable<T>> GetAllAsync(string userID);
    }
}
