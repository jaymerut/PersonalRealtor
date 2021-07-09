using System;
using Twilio;
using Twilio.Rest.Conversations.V1;
using Twilio.Rest.Conversations.V1.Conversation;
using MonkeyCache.FileStore;
using System.Collections.Generic;
using PersonalRealtor.Services.Delegates;

namespace PersonalRealtor.Services {
    public class ConversationResourceService : IConversationResourceService {
        private readonly string AccountSid = "AC7d1a4f19e72644a7c9caf6285aa9c2cf";
        private readonly string AuthToken = "13f775147193fbc04d7d1e789d06fd00";
        private readonly string ConversationResourceBarrelKey = "ConversationResourceService";
        private readonly string ParticipantResourceBarrelKey = "ParticipantResourceService";
        public ConversationResourceService() {
            TwilioClient.Init(AccountSid, AuthToken);
            Barrel.ApplicationId = "ConversationResource";
        }

        public void CreateConversationResource(string name) {
            var service = ConversationResource.Create(
                friendlyName: name
            );

            var conversationSid = Barrel.Current.Get<string>(key: ConversationResourceBarrelKey);

            if (string.IsNullOrEmpty(conversationSid)) {
                Barrel.Current.Add(key: ConversationResourceBarrelKey, data: service.Sid, expireIn: TimeSpan.FromDays(365));
            }
        }

        public void CreateParticipantResource(string phoneNumber) {
            var participant = ParticipantResource.Create(
                messagingBindingAddress: phoneNumber,
                messagingBindingProxyAddress: "+19844648497",
                pathConversationSid: Barrel.Current.Get<string>(key: ConversationResourceBarrelKey)
            );

            var participantSid = Barrel.Current.Get<string>(key: ParticipantResourceBarrelKey);

            if (string.IsNullOrEmpty(participantSid)) {
                Barrel.Current.Add(key: ParticipantResourceBarrelKey, data: participant.Sid, expireIn: TimeSpan.FromDays(365));
            }
        }

        public void CreateMessage(string name, string body) {
            var message = MessageResource.Create(
                author: name,
                body: body,
                pathConversationSid: Barrel.Current.Get<string>(key: ConversationResourceBarrelKey)
            );
        }

        public List<ConversationResource> RetrieveConversations() {
            List<ConversationResource> conversationResources = new List<ConversationResource>();
            var conversations = ConversationResource.Read(limit: 20);

            foreach (var record in conversations) {
                conversationResources.Add(record);
            }

            return conversationResources;
        }
        public List<MessageResource> RetrieveMessages() {
            List<MessageResource> messageResources = new List<MessageResource>();
            var messages = MessageResource.Read(
                pathConversationSid: Barrel.Current.Get<string>(key: ConversationResourceBarrelKey)
            );

            foreach (var message in messages) {
                messageResources.Add(message);
            }

            return messageResources;
        }
    }
}
