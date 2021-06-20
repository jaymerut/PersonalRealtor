using System;
using System.Collections.Generic;

namespace PersonalRealtor.ViewModels {
    public class SavedHomesViewModel {
        public List<SavedHome> SavedPropertyHomes { get; set; }

        public SavedHomesViewModel() {
            this.SavedPropertyHomes = new List<SavedHome>();
        }
    }

    public class SavedHome {
        public string PropertyId { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Sqft { get; set; }
    }
}
