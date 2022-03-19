using System;
using Plugin.CloudFirestore.Attributes;

namespace PersonalRealtor.Network.Firestore.Messages.Models {
    public class MessageDocument {
        public string Id { get; set; }
        public string PlayerId { get; set; }

        public MessageDocument(string id, string playerId) {
            Id = id;
            PlayerId = playerId;
        }
    }
}
