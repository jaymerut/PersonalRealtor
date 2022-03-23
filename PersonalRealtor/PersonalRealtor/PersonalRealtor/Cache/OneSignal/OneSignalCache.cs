using System;
using MonkeyCache.FileStore;

namespace PersonalRealtor.Cache.OneSignal {
    public class OneSignalCache {
        private static string BarrelKey = "OneSignalCache";

        public static void RegisterPlayerID(string playerID) {
            Barrel.Current.Add(key: BarrelKey, data: playerID, expireIn: TimeSpan.FromDays(365));
        }
        public static string GetPlayerID() {
            return Barrel.Current.Get<string>(key: BarrelKey);
        }
    }
}
