using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkSimulation.Model.Simulation
{
    public class PythonSimulationDirector : SimulationDirector
    {

        private IntPtr threadState;

        #region Methods

        protected override void OnStarted()
        {
            if (!PythonEngine.IsInitialized)
            {
                PythonEngine.Initialize();
                threadState = PythonEngine.BeginAllowThreads();
            }
            base.OnStarted();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        protected override Task BeginSimulation(List<int[]> attributes)
        {
            return Engine.WorkOnSimulationAsync(m =>
            {
                m.StartSimluation(attributes);
            });
        }

        protected override Task<T> BeginSimulation<T>(List<int[]> attributes)
        {
            return Engine.WorkOnSimulationAsync(m =>
            {
                dynamic result = m.StartSimulation(attributes);

                return (T)result;
            });
        }

        protected override SimulationEngine CreateEngine()
            => new PythonSimulationEngine();

        #endregion

    }
}
