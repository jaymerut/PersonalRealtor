using System;
namespace PersonalRealtor.ViewModels
{
    public class PropertyTaxViewModel
    {
        public string Year { get; set; }
        public int? Taxes { get; set; }
        public int? Land { get; set; }
        public int? Additions { get; set; }
        public int? Total { get; set; }

        public PropertyTaxViewModel()
        {
        }

        public string GetTaxesString()
        {
            return Taxes > 0 ? $"${(Taxes ?? 0).ToString("N0")}" : "N/A";
        }

        public string GetLandString()
        {
            return Land > 0 ? $"${(Land ?? 0).ToString("N0")}" : "N/A";
        }

        public string GetAdditionsString()
        {
            return Additions > 0 ? $"${(Additions ?? 0).ToString("N0")}" : "N/A";
        }

        public string GetTotalString()
        {
            return Total > 0 ? $"${(Total ?? 0).ToString("N0")}" : "N/A";
        }
    }
}
