using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.GeneralInquiry.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralInquiryPage : ContentPage
    {
        public GeneralInquiryPage()
        {
            InitializeComponent();

            SetUpGeneralInquiryPage();
        }

        private void SetUpGeneralInquiryPage()
        {
            this.LabelTitle.Text = $"Email {RealtorSingleton.Instance.FullName}: ";
        }
    }
}