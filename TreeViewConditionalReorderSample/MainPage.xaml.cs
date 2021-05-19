using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

using MUXC = Microsoft.UI.Xaml.Controls;

namespace TreeViewConditionalReorderSample
{
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<TreeViewData> DataSource { get; set; }
        public static List<TreeViewData> DraggedItems { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DraggedItems = new List<TreeViewData>();
            var item1 = new TreeViewData() { Content = "Group 1", IsGroup = true };
            item1.Children.Add(new TreeViewData() { Content = "Leaf 1.1", IsGroup = false, Parent = item1 });
            item1.Children.Add(new TreeViewData() { Content = "Leaf 1.2", IsGroup = false, Parent = item1 });
            var item2 = new TreeViewData() { Content = "Leaf 1", IsGroup = false };
            var item3 = new TreeViewData() { Content = "Leaf 2", IsGroup = false };
            var item4 = new TreeViewData() { Content = "Leaf 3", IsGroup = false };
            var item5 = new TreeViewData() { Content = "Group 2", IsGroup = true };
            var item6 = new TreeViewData() { Content = "Group 3", IsGroup = true };
            var item7 = new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 };
            item6.Children.Add(new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 });
            item6.Children.Add(new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 });
            item6.Children.Add(new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 });
            item6.Children.Add(new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 });
            item6.Children.Add(new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 });
            item6.Children.Add(new TreeViewData() { Content = "Leaf 3", IsGroup = false, Parent = item6 });
            DataSource = new ObservableCollection<TreeViewData> { item6, item2, item3, item4, item5, item1, item7 };
            for (int i = 4; i < 100; i++) DataSource.Add(new TreeViewData() { Content = "Group " + i.ToString(), IsGroup = true });
        }

        private void TreeView_DragItemsStarting(MUXC.TreeView sender, MUXC.TreeViewDragItemsStartingEventArgs args)
        {
            foreach (TreeViewData item in args.Items)
            {
                DraggedItems.Add(item);
            }
        }

        private void TreeView_DragItemsCompleted(MUXC.TreeView sender, MUXC.TreeViewDragItemsCompletedEventArgs args)
        {
            foreach (TreeViewData item in args.Items)
            {
                item.Parent = args.NewParentItem as TreeViewData;
            }

            DraggedItems.Clear();
        }
    }
}
