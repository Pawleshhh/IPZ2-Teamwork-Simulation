using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public class SimulationResultCollection : ISimulationResult
    {

        #region Constructors

        public SimulationResultCollection(IEnumerable<ISimulationResult> results, string name)
        {
            this.results = new List<ISimulationResult>(results);
            this.Name = name;
        }

        #endregion

        #region Private fields

        private List<ISimulationResult> results;

        #endregion

        #region Properties

        public string Name { get; }

        public IReadOnlyList<ISimulationResult> Result => results;
        //IReadOnlyList<ISimulationResult> ISimulationResultCollection.Result => (IReadOnlyList<ISimulationResult>)results;
        object ISimulationResult.Result => results;

        #endregion

    }
}
