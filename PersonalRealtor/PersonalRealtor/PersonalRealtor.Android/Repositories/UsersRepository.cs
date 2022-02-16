using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Droid.Extensions;
using PersonalRealtor.Droid.Services;
using PersonalRealtor.Network.Firestore.Models;
using PersonalRealtor.Network.Firestore.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(PersonalRealtor.Droid.Repositories.UsersRepository))]
namespace PersonalRealtor.Droid.Repositories {
    public class UsersRepository : IRepository<User> {
        public IEnumerable<User> GetAll() {
            return this.GetAllAsync().Result;
        }

        public Task<IEnumerable<User>> GetAllAsync() {
            return FirestoreService.Instance
                                   .Collection("Users")
                                   .GetCollectionAsync<User>();
        }

        public User GetOne(string id) {
            return this.GetOneAsync(id).Result;
        }

        public Task<User> GetOneAsync(string id) {
            return FirestoreService.Instance
                                   .Collection("Users")
                                   .Document(id)
                                   .GetDocumentAsync<User>();
        }
    }
}
