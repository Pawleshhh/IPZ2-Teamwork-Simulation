using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class OpenSimulationResultsWindow : IOpenView
    {

        private SimulationResultsWindow resultsWindow;

        public void OpenView(object parameter)
        {
            resultsWindow = new SimulationResultsWindow();

            resultsWindow.DataContext = (SimulationResultDirectorViewModel)parameter;

            resultsWindow.Show();
        }
    }
}
