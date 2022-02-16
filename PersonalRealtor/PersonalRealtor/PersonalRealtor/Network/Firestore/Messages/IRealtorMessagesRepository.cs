using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalRealtor.Network.Firestore.Messages {
    public interface IRealtorMessagesRepository<T> {
        T GetOne(string userID);
        Task<T> GetOneAsync(string userID);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
    }
}
