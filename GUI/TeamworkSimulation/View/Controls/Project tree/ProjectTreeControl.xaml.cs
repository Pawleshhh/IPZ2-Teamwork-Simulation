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
    /// Interaction logic for ProjectTreeControl.xaml
    /// </summary>
    public partial class ProjectTreeControl : UserControl
    {

        //public ICommand ChangeWorkplace
        //{
        //    get { return (ICommand)GetValue(ChangeWorkplaceProperty); }
        //    set { SetValue(ChangeWorkplaceProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ChangeWorkplace.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ChangeWorkplaceProperty =
        //    DependencyProperty.Register("ChangeWorkplace", typeof(ICommand), typeof(ProjectTreeControl), null);

        public ProjectTreeControl()
        {
            InitializeComponent();
        }

        //private static ProjectTreeContextMenuSelector contextMenuSelector = new ProjectTreeContextMenuSelector();
        //private static ProjectTreeItemSelector projectTreeItemSelector = new ProjectTreeItemSelector();

        //private void itemsControl_Initialized(object sender, EventArgs e)
        //{
        //    //ItemsControl itemsControl = sender as ItemsControl;

        //    //itemsControl.ContextMenu = contextMenuSelector.SelectContextMenu(itemsControl.DataContext, this);
        //    //var t = projectTreeItemSelector.SelectTemplate(itemsControl.DataContext, this);
        //    //itemsControl.ItemTemplate = t;
        //}

        //private void treeItemContentControl_Initialized(object sender, EventArgs e)
        //{
        //    //ContentControl contentControl = sender as ContentControl;

        //    //contentControl.ContentTemplate = projectTreeItemSelector.SelectTemplate(contentControl.DataContext, this);
        //}

        private void ImageAwesome_Initialized(object sender, EventArgs e)
        {
            ImageAwesome img = sender as ImageAwesome;

            switch(img.DataContext)
            {
                case WorkplaceViewModel _:
                    img.Icon = FontAwesomeIcon.BuildingOutline;
                    break;
                case TeamViewModel _:
                    img.Icon = FontAwesomeIcon.Group;
                    break;
                case TeamMemberViewModel _:
                    img.Icon = FontAwesomeIcon.Male;
                    break;
            }
        }

        //private void TextBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;

        //    if (textBox.Visibility == Visibility.Visible)
        //    {
        //        textBox.Focus();
        //        textBox.SelectAll();
        //    }
        //}

        private void itemsControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
                ((TextBlock)sender).Focus();
        }

    }
}
