using System;
using System.Collections.Generic;
using PersonalRealtor.Models;

namespace PersonalRealtor.ViewModels
{
    public class PhotoViewModel
    {
        public string PropertyId { get; set; }
        public List<Photo> Photos { get; set; }
        public string PropStatus { get; set; }

        public PhotoViewModel()
        {

        }

        public bool IsForSale()
        {
            return PropStatus.ToLower().Equals("for_sale");
        }
        public bool IsForRent()
        {
            return PropStatus.ToLower().Equals("for_rent");
        }
        public bool IsSold()
        {
            return PropStatus.ToLower().Equals("not_for_sale") || PropStatus.ToLower().Equals("recently_sold");
        }
    }
}
