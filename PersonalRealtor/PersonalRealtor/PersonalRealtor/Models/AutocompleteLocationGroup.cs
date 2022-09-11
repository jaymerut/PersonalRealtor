using System;
using System.Collections.Generic;

namespace PersonalRealtor.Models {
    public class AutocompleteLocationGroup {
        public string GroupName { get; set; }
        public List<AutocompleteLocation> Values { get; set; }
    }
}
