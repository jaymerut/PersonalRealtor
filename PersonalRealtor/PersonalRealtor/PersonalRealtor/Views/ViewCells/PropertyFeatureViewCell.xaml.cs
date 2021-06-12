using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyFeatureViewCell : ViewCell
    {
        private PropertyFeatureViewModel ViewModel;

        public PropertyFeatureViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupPropertyFeatureViewCell();
        }

        private void SetupPropertyFeatureViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (PropertyFeatureViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdatePropertyFeature();
        }

        private void UpdatePropertyFeature()
        {
            LabelName.Text = this.ViewModel.Name;
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            // Create 2xn Grid (2 columns, n rows)

            int row = 0;
            int column = 0;

            this.GridFeature.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            foreach (var text in this.ViewModel.Text)
            {

                var stackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.StartAndExpand
                };

                var image = new Image
                {
                    Margin = new Thickness(0, 8, 0, 0),
                    Source = "bullet_point.png",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    HeightRequest = 5
                };
                var label = new Label
                {
                    LineBreakMode = LineBreakMode.WordWrap,
                    Text = text,
                    FontSize = 14,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = new Thickness(0, 0, 0, 0),
                    Padding = new Thickness(0, 0, 0, 0)
                };


                stackLayout.VerticalOptions = LayoutOptions.Start;
                stackLayout.Children.Add(image);
                stackLayout.Children.Add(label);

                this.GridFeature.Children.Add(stackLayout, column, row);

                if (column < 1)
                {
                    column++;
                }
                else
                {
                    column = 0;
                    row++;
                    this.GridFeature.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
                }
            }

            this.GridFeature.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        }
    }
}
