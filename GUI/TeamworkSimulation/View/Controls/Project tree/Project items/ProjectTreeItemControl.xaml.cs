using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    /// <summary>
    /// Interaction logic for ProjectTreeItemControl.xaml
    /// </summary>
    public partial class ProjectTreeItemControl : UserControl
    {

        public FontAwesomeIcon ItemIcon
        {
            get { return (FontAwesomeIcon)GetValue(ItemIconProperty); }
            set { SetValue(ItemIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.Register("ItemIcon", typeof(FontAwesomeIcon), typeof(ProjectTreeItemControl), new PropertyMetadata(FontAwesomeIcon.QuestionCircle));

        //private static void ItemIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ProjectTreeItemControl item = d as ProjectTreeItemControl;

        //    switch (item.DataContext)
        //    {
        //        case WorkplaceViewModel _:
        //            item.ItemIcon = FontAwesomeIcon.BuildingOutline;
        //            break;
        //        case TeamViewModel _:
        //            item.ItemIcon = FontAwesomeIcon.Group;
        //            break;
        //        case TeamMemberViewModel _:
        //            item.ItemIcon = FontAwesomeIcon.Male;
        //            break;
        //    }
        //}

        public ProjectTreeItemControl()
        {
            InitializeComponent();
        }


        private void TextBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Visibility == Visibility.Visible)
            {
                textBox.Focus();
                textBox.SelectAll();
            }
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject source = Parent;
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            if (source != null)
                ((TreeViewItem)source).Focus();
        }
    }
}
