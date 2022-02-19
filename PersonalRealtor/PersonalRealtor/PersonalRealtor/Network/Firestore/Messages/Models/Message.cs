using System;
namespace PersonalRealtor.Network.Firestore.Messages.Models {
    public class Message {

        public string MessageID { get; set; }
        public string ParticipantID { get; set; }
        public string AuthorID { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }

        public Message() { }
    }
}
