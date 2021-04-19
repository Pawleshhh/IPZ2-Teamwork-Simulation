using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamworkSimulation.View.Windows;

namespace TeamworkSimulation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SimulationResultsWindow simulationWidnow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            simulationWidnow = new SimulationResultsWindow(
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } },
                new List<double[]>() { new double[] { 1, 2, 3 } });

            simulationWidnow.Show();
        }
    }
}
