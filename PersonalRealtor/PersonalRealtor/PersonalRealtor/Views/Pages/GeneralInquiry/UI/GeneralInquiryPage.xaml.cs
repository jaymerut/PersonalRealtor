﻿using System;
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

            this.ButtonSite.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSite.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);

            this.FrameGeneralInquiry.BorderColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);

            this.ButtonSend.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonSend.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
        }

        public async void ButtonSend_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = $"{EntryName.Text} General Inquiry",
                    Body = EditorMessage.Text,
                    To = new List<string>() { EntryEmail.Text },
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

        public void ButtonSite_Clicked(System.Object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri(RealtorSingleton.Instance.WebsiteURL));
        }
    }
}