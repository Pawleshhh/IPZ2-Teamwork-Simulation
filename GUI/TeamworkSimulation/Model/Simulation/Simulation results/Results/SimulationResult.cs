using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public abstract class SimulationResult<T> : ISimulationResult
    {

        #region Constructors

        public SimulationResult(T result)
        {
            Result = result;
        }

        #endregion

        #region Properties

        public abstract string Name { get; }

        public T Result { get; }

        object ISimulationResult.Result => Result;

        #endregion
    }
}
