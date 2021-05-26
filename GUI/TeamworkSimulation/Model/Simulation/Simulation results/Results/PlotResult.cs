using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class PlotResult : SimulationResult<List<double[]>>
    {

        #region Constructors
        public PlotResult(List<double[]> results, string name) : base(results)
        {
            Name = name;
        }
        #endregion

        #region Properties
        public override string Name { get; }
        #endregion

    }
}
