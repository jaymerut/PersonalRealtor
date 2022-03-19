using System;
using System.Threading.Tasks;
using PersonalRealtor.Network.Firestore.OneSignal.Models;

namespace PersonalRealtor.Network.Firestore.OneSignal.Repositories.RealtorOneSignal {
    public interface IRealtorOneSignalRepository {
        Task<OneSignalInfo> GetRealtorOneSignalInfoAsync(string id);
        void UpdatePlayerId(OneSignalInfo oneSignalInfo);
    }
}
