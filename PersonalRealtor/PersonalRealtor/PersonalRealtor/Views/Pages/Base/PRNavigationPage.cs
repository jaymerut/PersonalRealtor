using System;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.Base
{
    public class PRNavigationPage : NavigationPage
    {

        #region - Variables
        #endregion



        #region - Constructors
        public PRNavigationPage()
        {

            // Setup
            SetupPRNavigationPage();
        }
        public PRNavigationPage(Page root) : base(root)
        {

            // Setup

            SetupPRNavigationPage();
        }
        #endregion



        #region - NavigationPage LifeCycle Methods
        #endregion



        #region - Private API
        private void SetupPRNavigationPage()
        {
            this.BackgroundColor = Color.Black;

            // This

        }
        #endregion



        #region - Public API
        #endregion

    }
}
