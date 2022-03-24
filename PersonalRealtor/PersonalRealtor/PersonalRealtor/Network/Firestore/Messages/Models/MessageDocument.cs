using System;
using Plugin.CloudFirestore.Attributes;

namespace PersonalRealtor.Network.Firestore.Messages.Models {
    public class MessageDocument {
        public string Id { get; set; }
        public string Username { get; set; }

        public MessageDocument() { }
        public MessageDocument(string id, string username) {
            Id = id;
            Username = username;
        }
    }
}
