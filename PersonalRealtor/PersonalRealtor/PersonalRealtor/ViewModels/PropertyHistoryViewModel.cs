using System;
namespace PersonalRealtor.ViewModels
{
    public class PropertyHistoryViewModel
    {
        public string EventName { get; set; }
        public DateTime? Date { get; set; }
        public long? Price { get; set; }
        public int? Sqft { get; set; }
        public string DataSourceName { get; set; }

        public PropertyHistoryViewModel()
        {
        }

        public string GetPriceString()
        {
            return Price > 0 ? $"${(Price ?? 0).ToString("N0")}" : " - ";
        }

        public string GetPricePerSqftString()
        {

            return Sqft > 0 ? $"${(Price/Sqft ?? 0).ToString("N0")}" : " - ";
        }
    }
}
