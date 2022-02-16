using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.iOS.Extensions;
using PersonalRealtor.iOS.Services;
using PersonalRealtor.Network.Firestore.Models;
using PersonalRealtor.Network.Firestore.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(PersonalRealtor.iOS.Repositories.UsersRepository))]
namespace PersonalRealtor.iOS.Repositories {
    public class UsersRepository : IRepository<User> {
        public IEnumerable<User> GetAll() {
            return this.GetAllAsync().Result;
        }

        public Task<IEnumerable<User>> GetAllAsync() {
            return FirestoreService.Instance
                                   .GetCollection("Users")
                                   .GetCollectionAsync<User>();
        }

        public User GetOne(string id) {
            return this.GetOneAsync(id).Result;
        }

        public Task<User> GetOneAsync(string id) {
            return FirestoreService.Instance
                                   .GetCollection("Users")
                                   .GetDocument(id)
                                   .GetDocumentAsync<User>();
        }
    }
}
