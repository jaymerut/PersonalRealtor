using System;
using System.Collections.Generic;
using MonkeyCache.FileStore;

namespace PersonalRealtor.Cache.HiddenConversation {
    public class HiddenConversationCache {
        private static string BarrelKey = "HiddenConversationCache";

        public static void HideConversation(string playerID) {
            var hiddenConversations = GetHiddenConversations();
            if (!hiddenConversations.Contains(playerID)) { hiddenConversations.Add(playerID); }

            Barrel.Current.Add(key: BarrelKey, data: hiddenConversations, expireIn: TimeSpan.FromDays(999));
        }
        public static List<string> GetHiddenConversations() {
            return Barrel.Current.Get<List<string>>(key: BarrelKey) ?? new List<string>();
        }
    }
}
