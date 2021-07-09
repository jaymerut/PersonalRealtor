using System.Collections.Generic;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using MonkeyCache.FileStore;
using PersonalRealtor.Views.Pages.Base;
using PersonalRealtor.Views.Pages.BrowseListings.UI;
using PersonalRealtor.Views.Pages.GeneralInquiry.Composer;
using PersonalRealtor.Views.Pages.Main.Composer;
using PersonalRealtor.Views.Pages.Main.UI;
using PersonalRealtor.Views.Pages.Menu;
using PersonalRealtor.Views.Pages.Menu.Composer;
using PersonalRealtor.Views.Pages.RealtorChat.Composer;
using PersonalRealtor.Views.Pages.RealtorChatList.Composer;
using PersonalRealtor.Views.Pages.RealtorListings.Composer;
using PersonalRealtor.Views.Pages.SavedHomes.Composer;
using Xamarin.Forms;

namespace PersonalRealtor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "RealtorListings";

            MainPage = MakeMainUI();

            //Remove this method to stop OneSignal Debugging  
            OneSignal.Current.SetLogLevel(LOG_LEVEL.VERBOSE, LOG_LEVEL.NONE);

            OneSignal.Current.StartInit("1c757b00-e5c4-4309-954c-e02d24304b80")
            .Settings(new Dictionary<string, bool>() {
                { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                { IOSSettings.kOSSettingsKeyInAppLaunchURL, false } })
            .InFocusDisplaying(OSInFocusDisplayOption.Notification)
            .EndInit();

            // The promptForPushNotificationsWithUserResponse function will show the iOS push notification prompt. We recommend removing the following code and instead using an In-App Message to prompt for notification permission (See step 7)
            OneSignal.Current.RegisterForPushNotifications();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private MainPage MakeMainUI()
        {
            var main = MainUIComposer.MainUI();
            main.Flyout = MenuUIComposer.MenuUI(MakeMenuOptions(main));
            main.Detail = new PRNavigationPage(new BrowseListingsPage());
            ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
            return main;
        }
        private MenuOption<Image>[] MakeMenuOptions(MainPage main)
        {
            return new MenuOption<Image>[] {
                new MenuOption<Image>() {
                    Title = $"View {RealtorSingleton.Instance.FullName}'s Listings",
                    Image = new Image() { Source = "menu_realtor_listings.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(RealtorListingsUIComposer.MakeRealtorListingsUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Browse Homes",
                    Image = new Image() { Source = "menu_browse_listings.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(new BrowseListingsPage());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "My Saved Homes",
                    Image = new Image() { Source = "menu_my_saved_homes.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(SavedHomesUIComposer.MakeSavedHomesUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "General Inquiry",
                    Image = new Image() { Source = "menu_general_inquiry.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(GeneralInquiryUIComposer.MakeGeneralInquiryUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Chat With Your Realtor!",
                    Image = new Image() { Source = "menu_chat.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(RealtorChatListUIComposer.MakeRealtorChatListUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                }
            };
        }
    }
}
