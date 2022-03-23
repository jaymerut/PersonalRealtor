using System;
using MonkeyCache.FileStore;

namespace PersonalRealtor.Cache.Username {
    public class UsernameCache {
        private static string BarrelKey = "UsernameCache";

        public static bool HasUsername() {
            return !string.IsNullOrEmpty(Barrel.Current.Get<string>(key: BarrelKey));
        }
        public static void CreateUsername(string username) {
            Barrel.Current.Add(key: BarrelKey, data: username, expireIn: TimeSpan.FromDays(365));
        }
        public static void RemoveUsername(string username) {
            Barrel.Current.Add(key: BarrelKey, data: username, expireIn: TimeSpan.FromDays(365));
        }
        public static string GetCurrentUsername() {
            //return Barrel.Current.Get<string>(key: BarrelKey);
            return "User100";
        }
    }
}
