using System;
using MonkeyCache.FileStore;

namespace PersonalRealtor.Cache.OneSignal {
    public class RealtorOneSignalCache {
        private static string BarrelKey = "RealtorOneSignalCache";

        public static void SaveRealtorPlayerID(string playerID) {
            Barrel.Current.Add(key: BarrelKey, data: playerID, expireIn: TimeSpan.FromDays(365));
        }
        public static string GetRealtorPlayerID() {
            return Barrel.Current.Get<string>(key: BarrelKey);
        }
    }
}
