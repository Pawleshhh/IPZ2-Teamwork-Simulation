using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public interface ISimulationResult
    {

        string Name { get; }

        object Result { get; }

    }
}
