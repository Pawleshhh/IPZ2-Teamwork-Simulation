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
    /// Interaction logic for WorkerControl.xaml
    /// </summary>
    public partial class TeamMember : UserControl
    {
        public TeamMember()
        {
            InitializeComponent();
            DataContextChanged += TeamMember_DataContextChanged;
        }

        private static TeamMemberTemplateSelector selector = new TeamMemberTemplateSelector();

        private void TeamMember_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            contentControl.ContentTemplate = selector.SelectTemplate(DataContext, this);
        }


    }
}
