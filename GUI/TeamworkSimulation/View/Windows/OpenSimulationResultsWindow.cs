using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class OpenSimulationResultsWindow : IOpenView
    {

        private SimulationResultsWindow resultsWindow;

        public bool IsOpened { get; private set; }

        public void OpenView(object parameter)
        {
            resultsWindow = new SimulationResultsWindow();

            IsOpened = true;
            resultsWindow.Closed += (s, e) => IsOpened = false;

            resultsWindow.DataContext = (SimulationResultDirectorViewModel)parameter;

            resultsWindow.Show();
        }

        public void CloseView()
        {
            resultsWindow?.Close();
        }
    }
}
