using Twilio.Rest.Conversations.V1;
using Twilio.Rest.Conversations.V1.Conversation;
using System.Collections.Generic;
namespace PersonalRealtor.Services.Delegates {
    public interface IConversationResourceService {
        void CreateConversationResource(string name);
        void CreateParticipantResource(string phoneNumber);
        void CreateMessage(string name, string body);
        List<ConversationResource> RetrieveConversations();
        List<MessageResource> RetrieveMessages();
    }
}
