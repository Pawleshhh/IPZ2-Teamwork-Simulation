using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TeamworkSimulation.ViewModel
{
    public interface ISimulationResultCollectionViewModel : IViewModel
    {

        IReadOnlyList<SimulationResultViewModel> SimulationResultVMs { get; }

        string Name { get; }

    }
}
