using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalRealtor.Network.Firestore.Users {
    public interface IUsersRepository<T> {
        T GetOne(string id);
        Task<T> GetOneAsync(string id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
    }
}
