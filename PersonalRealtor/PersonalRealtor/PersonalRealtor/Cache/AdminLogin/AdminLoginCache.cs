using System;
using MonkeyCache.FileStore;

namespace PersonalRealtor.Cache.AdminLogin {
    public class AdminLoginCache {

        private static string BarrelKey = RealtorSingleton.Instance.UserName;

        public static bool IsAdminLoggedIn() {
            return Barrel.Current.Get<bool>(key: BarrelKey);
        }
        public static void AdminLogin() {
            Barrel.Current.Add(key: BarrelKey, data: true, expireIn: TimeSpan.FromDays(365));
        }
        public static void AdminLogout() {
            Barrel.Current.Add(key: BarrelKey, data: false, expireIn: TimeSpan.FromDays(365));
        }
    }
}
