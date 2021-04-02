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

namespace TeamworkSimulation.View
{
    /// <summary>
    /// Interaction logic for WorkplaceProjectTreeItemControl.xaml
    /// </summary>
    public partial class WorkplaceProjectTreeItemControl : UserControl
    {

        public ICommand ChangeCurrentWorkplace
        {
            get { return (ICommand)GetValue(ChangeCurrentWorkplaceProperty); }
            set { SetValue(ChangeCurrentWorkplaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChangeCurrentWorkplace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeCurrentWorkplaceProperty =
            DependencyProperty.Register("ChangeCurrentWorkplace", typeof(ICommand), typeof(WorkplaceProjectTreeItemControl));

        public ICommand RemoveWorkplace
        {
            get { return (ICommand)GetValue(RemoveWorkplaceProperty); }
            set { SetValue(RemoveWorkplaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveWorkplace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveWorkplaceProperty =
            DependencyProperty.Register("RemoveWorkplace", typeof(ICommand), typeof(WorkplaceProjectTreeItemControl));



        public WorkplaceProjectTreeItemControl()
        {
            InitializeComponent();
        }
    }
}
