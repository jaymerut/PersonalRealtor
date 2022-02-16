using System;
namespace PersonalRealtor.Network.Firestore.Models {
    public class User {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
