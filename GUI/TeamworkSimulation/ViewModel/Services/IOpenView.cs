using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.ViewModel
{
    public interface IOpenView
    {

        bool IsOpened { get; }

        void OpenView(object parameter);

        void CloseView();

    }
}
