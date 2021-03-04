using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkSimulation.Model.Simulation
{
    public abstract class SimulationEngine : IDisposable
    {

        #region Properties

        #endregion

        #region Methods

        public abstract void WorkOnSimulation(Action<dynamic> action);
        public abstract T WorkOnSimulation<T>(Func<dynamic, T> func);

        public abstract Task WorkOnSimulationAsync(Action<dynamic> action);
        public abstract Task<T> WorkOnSimulationAsync<T>(Func<dynamic, T> func);

        public abstract void Dispose();
        #endregion

    }
}
