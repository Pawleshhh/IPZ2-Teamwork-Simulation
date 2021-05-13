using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    public interface IModelItem : IProjectItem
    {

        bool UseModel { get; set; }

        ISimulationModel SimulationModel { get; }

        event EventHandler UseModelChanged;

    }
}
