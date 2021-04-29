using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public abstract class SimulationResultCollection<T> : ISimulationResultCollection
        where T : ISimulationResult
    {

        #region Constructors

        public SimulationResultCollection(IEnumerable<T> results)
        {
            this.results = new List<T>(results);
        }

        #endregion

        #region Private fields

        private List<T> results;

        #endregion

        #region Properties

        public IReadOnlyList<T> Results => results;

        IReadOnlyList<ISimulationResult> ISimulationResultCollection.Results =>
            (IReadOnlyList<ISimulationResult>)results;

        #endregion

    }
}
