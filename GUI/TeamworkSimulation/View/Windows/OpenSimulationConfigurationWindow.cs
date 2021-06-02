using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class OpenSimulationConfigurationWindow : IOpenView
    {
        private SimulationConfigurationWindow configWindow;

        public bool IsOpened { get; private set; }

        public void OpenView(object parameter)
        {
            configWindow = new SimulationConfigurationWindow();

            IsOpened = true;
            configWindow.Closed += (s, e) => IsOpened = false;

            configWindow.DataContext = parameter;

            configWindow.Show();
        }

        public void CloseView()
        {
            configWindow?.Close();
        }
    }
}
