using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        public async void ButtonSend_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Subject",
                    Body = "Body",
                    To = new List<string>() { "Receipent@test.com" },
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device  
            }
            catch (Exception ex)
            {
                // Some other exception occurred  
            }
        }
    }
}