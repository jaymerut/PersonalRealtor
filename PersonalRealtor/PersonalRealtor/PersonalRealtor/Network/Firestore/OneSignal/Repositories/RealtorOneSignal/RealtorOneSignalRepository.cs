using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.OneSignal.Models;
using Plugin.CloudFirestore;

namespace PersonalRealtor.Network.Firestore.OneSignal.Repositories.RealtorOneSignal {
    public class RealtorOneSignalRepository : IRealtorOneSignalRepository {
        public RealtorOneSignalRepository() {
        }

        public async Task<OneSignalInfo> GetRealtorOneSignalInfoAsync(string id) {
            var result = await CrossCloudFirestore.Current.Instance
                .Collection("RealtorOneSignal")
                .Document(id).GetAsync().ConfigureAwait(true);
            return result.ToObject<OneSignalInfo>();
        }

        public void UpdatePlayerId(OneSignalInfo oneSignalInfo) {
            CrossCloudFirestore.Current.Instance
                .Collection("RealtorOneSignal")
                .Document(oneSignalInfo.Id)
                .SetAsync(oneSignalInfo);
        }
    }
}
