using System;
using Firebase.Firestore;

namespace PersonalRealtor.Droid.Services {
    public static class FirestoreService {
        private static Firebase.FirebaseApp app;
        public static FirebaseFirestore Instance {
            get {
                return FirebaseFirestore.GetInstance(app);
            }
        }

        public static string AppName { get; } = "PersonalRealtor";

        public static void Init(Android.Content.Context context) {
            var baseOptions = Firebase.FirebaseOptions.FromResource(context);
            //var options = new Firebase.FirebaseOptions.Builder(baseOptions).SetProjectId(baseOptions.StorageBucket.Split('.')[0]).Build();
            app = Firebase.FirebaseApp.InitializeApp(context);
        }
    }
}
