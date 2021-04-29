using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public class SimulationResultDirector
    {

        #region Constructors
        public SimulationResultDirector(IEnumerable<ISimulationResultCollection> resultCollections)
        {
            this.resultCollections = new List<ISimulationResultCollection>(resultCollections);
        }
        #endregion

        #region Private fields

        private List<ISimulationResultCollection> resultCollections;

        #endregion

        #region Properties

        public IReadOnlyList<ISimulationResultCollection> ResultCollections => resultCollections;

        #endregion


    }
}
