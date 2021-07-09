using System;
using System.Collections.Generic;
using MonkeyCache.FileStore;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.Login.UI {
    public partial class LoginPage : ContentPage {
        #region - Variables
        private readonly string LoginBarrelKey = "AdminLogin";
        #endregion

        #region - Constructors
        public LoginPage() {
            this.BindingContext = this;

            InitializeComponent();

            SetUpLoginPage();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing() {
            base.OnAppearing();

        }
        #endregion

        #region - Private Methods
        private void SetUpLoginPage() {
            this.ButtonLogin.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonLogin.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);

            this.ButtonLogout.BackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            this.ButtonLogout.TextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);

            Refresh();
        }

        private void Refresh() {
            var isLoggedIn = Barrel.Current.Get<bool>(key: LoginBarrelKey);

            this.FrameLogin.IsVisible = !isLoggedIn;
            this.EntryUserName.IsVisible = !isLoggedIn;
            this.EntryPassword.IsVisible = !isLoggedIn;
            this.ButtonLogin.IsVisible = !isLoggedIn;
            this.ButtonLogout.IsVisible = isLoggedIn;
        }
        #endregion

        #region - Public API
        public void ButtonLogin_Clicked(System.Object sender, System.EventArgs e) {
            var userName = !string.IsNullOrEmpty(this.EntryUserName.Text) ? this.EntryUserName.Text.ToLower().Trim() : "";
            var password = this.EntryPassword.Text;

            if (userName == RealtorSingleton.Instance.UserName.ToLower() && password == RealtorSingleton.Instance.Password) {
                Barrel.Current.Add(key: LoginBarrelKey, data: true, expireIn: TimeSpan.FromDays(999));

                Refresh();
            } else if (userName != RealtorSingleton.Instance.UserName.ToLower() || password != RealtorSingleton.Instance.Password) {
                this.DisplayAlert("Login Error", "Username or Password is Incorrect", "Close");
            }
        }
        public void ButtonLogout_Clicked(System.Object sender, System.EventArgs e) {
            Barrel.Current.Add(key: LoginBarrelKey, data: false, expireIn: TimeSpan.FromDays(999));

            Refresh();
        }
        #endregion
    }
}
