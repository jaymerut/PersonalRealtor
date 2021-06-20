using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Components.Helpers;
using PersonalRealtor.Controls;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoViewCell : SelectableViewCell
    {
        private PhotoViewModel ViewModel;
        private BookmarkHelper BookmarkHelper = new BookmarkHelper();

        public PhotoViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupPhotoViewCell();
        }

        private void SetupPhotoViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (PhotoViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdatePhoto();
        }

        private void UpdatePhoto()
        {
            ImageButtonBookmark.Source = BookmarkHelper.IsBookmarked(this.ViewModel.SavedHome) ? "bookmark_selected.png" : "bookmark_unselected.png";
            ImageButtonBookmark.IsVisible = !this.ViewModel.IsSold();
            ImagePhoto.Source = this.ViewModel.Photos.FirstOrDefault().Href.Replace(".jpg", "-w1020_h770_q90.jpg");
            if (this.ViewModel.IsForSale())
            {
                LabelBadge.Text = "FOR SALE";
                LabelBadge.TextColor = Color.White;
                FrameBadge.BackgroundColor = Color.FromHex("#3D850A");
                this.FrameBadge.IsVisible = true;
            }
            else if (this.ViewModel.IsForRent())
            {
                LabelBadge.Text = "FOR RENT";
                LabelBadge.TextColor = Color.White;
                FrameBadge.BackgroundColor = Color.FromHex("#1C5B99");
                this.FrameBadge.IsVisible = true;
            }
            else if (this.ViewModel.IsSold())
            {
                LabelBadge.Text = "SOLD";
                LabelBadge.TextColor = Color.Black;
                FrameBadge.BackgroundColor = Color.FromHex("#EAEAEA");
                this.FrameBadge.IsVisible = true;
            }
        }

        private void ImageButtonBookmark_Clicked(System.Object sender, System.EventArgs e) {

            if (!BookmarkHelper.IsBookmarked(this.ViewModel.SavedHome)) {
                BookmarkHelper.AddToSavedHomes(this.ViewModel.SavedHome);
                this.ImageButtonBookmark.Source = "bookmark_selected.png";
            } else {
                BookmarkHelper.RemoveFromSavedHomes(this.ViewModel.SavedHome);
                this.ImageButtonBookmark.Source = "bookmark_unselected.png";
            }
        }
    }
}
