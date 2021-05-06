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
    /// Interaction logic for SimulationResultCollectionControl.xaml
    /// </summary>
    public partial class SimulationResultCollectionControl : UserControl
    {
        public SimulationResultCollectionControl()
        {
            InitializeComponent();
        }

        private static SimulationResultSelector simulationResultSelector = new SimulationResultSelector();

        private void mainContent_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            mainContent.ContentTemplate = simulationResultSelector.SelectTemplate(mainContent.DataContext, mainContent);
        }

        private void MainContent_ContentLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).DataContext = resultList.SelectedItem;
        }
    }
}
