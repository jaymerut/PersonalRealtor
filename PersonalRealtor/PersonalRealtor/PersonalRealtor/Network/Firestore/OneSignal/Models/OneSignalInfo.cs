using System;
namespace PersonalRealtor.Network.Firestore.OneSignal.Models {
    public class OneSignalInfo {
        public string Id { get; set; }
        public string PlayerId { get; set; }

        public OneSignalInfo() { }
        public OneSignalInfo(string id, string playerid) {
            Id = id;
            PlayerId = playerid;
        }
    }
}
