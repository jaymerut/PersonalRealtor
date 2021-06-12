using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Controls;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyInfoViewCell : SelectableViewCell
    {
        private PropertyInfoViewModel ViewModel;

        public PropertyInfoViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupPropertyInfoViewCell();
        }

        private void SetupPropertyInfoViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (PropertyInfoViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdatePropertyInfo();
        }

        private void UpdatePropertyInfo()
        {
            LabelStreetAddress.Text = this.ViewModel.Address.Line;
            LabelPrice.Text = this.ViewModel.GetListPriceString();
            LabelCityState.Text = this.ViewModel.Address.GetCityState();

            LabelBed.Text = $"{this.ViewModel.Beds} beds";
            LabelBath.Text = $"{this.ViewModel.BathsFull} baths";
            if (this.ViewModel.BuildingSize != null)
            {
                LabelSqft.Text = $"{(this.ViewModel.BuildingSize.Size).ToString("N0")} {this.ViewModel.BuildingSize.Units}";
                LabelSqft.IsVisible = this.ViewModel.BuildingSize.Size > 0;
            }


            LabelBed.IsVisible = this.ViewModel.Beds > 0;
            LabelBath.IsVisible = this.ViewModel.BathsFull > 0;
        }
    }
}
