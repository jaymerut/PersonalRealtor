using System;
using System.Collections.Generic;

namespace PersonalRealtor.ViewModels {
    public class SavedHomesViewModel {
        public List<string> SavedPropertyIds { get; set; }

        public SavedHomesViewModel() {
            this.SavedPropertyIds = new List<string>();
        }
    }
}
