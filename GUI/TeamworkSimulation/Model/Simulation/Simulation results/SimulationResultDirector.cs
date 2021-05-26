using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class SimulationResultDirector
    {

        #region Constructors
        public SimulationResultDirector(IEnumerable<ISimulationResult> results)
        {
            this.results = new List<ISimulationResult>(results);
        }
        #endregion

        #region Private fields

        private List<ISimulationResult> results;

        #endregion

        #region Properties

        public IReadOnlyList<ISimulationResult> Results => results;

        #endregion


    }
}
