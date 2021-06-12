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
    public partial class PropertyTaxViewCell : SelectableViewCell
    {
        private PropertyTaxViewModel ViewModel;

        public PropertyTaxViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupPropertyTaxViewCell();
        }

        private void SetupPropertyTaxViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (PropertyTaxViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdatePropertyTax();
        }

        private void UpdatePropertyTax()
        {
            // TODO: Update UI Here
        }
    }
}
