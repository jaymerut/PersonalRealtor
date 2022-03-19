using System;
using System.Linq;

namespace PersonalRealtor.Components.Helpers {
    public class RandomHelper {
        private static Random random = new Random();

        public static string RandomString(int length) {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
