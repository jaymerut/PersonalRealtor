using System;
using PersonalRealtor.Controls;
using PersonalRealtor.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SelectableViewCell), typeof(SelectableViewCellRenderer))]
namespace PersonalRealtor.iOS.Controls
{

    public class SelectableViewCellRenderer : ViewCellRenderer
    {

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as SelectableViewCell;
            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
            };

            return cell;
        }

    }
}
