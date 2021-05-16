using System;
using PersonalRealtor.Models;

namespace PersonalRealtor.ViewModels
{
    public class PropertyInfoViewModel
    {
        public PropertyDetailAddress Address { get; set; }
        public int? Beds { get; set; }
        public int? BathsFull { get; set; }
        public PropertyDetailsSize BuildingSize { get; set; }
        public long? Price { get; set; }

        public PropertyInfoViewModel()
        {
        }

        public string GetListPriceString()
        {
            return $"${(Price ?? 0).ToString("N0")}";
        }
    }
}
