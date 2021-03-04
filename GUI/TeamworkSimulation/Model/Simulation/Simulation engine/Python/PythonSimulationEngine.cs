using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace TeamworkSimulation.Model.Simulation
{
    public class PythonSimulationEngine : SimulationEngine
    {

        #region Constructors
        public PythonSimulationEngine()
        {
            //string pythonPath = @"C:\Program Files\Python39";

            //Environment.SetEnvironmentVariable("PATH", $@"{pythonPath};" + Environment.GetEnvironmentVariable("PATH"));
            //Environment.SetEnvironmentVariable("PYTHONHOME", pythonPath);

            //Environment.SetEnvironmentVariable("PYTHONPATH ", $@"{pythonPath}\..\Lib;{pythonPath}\..\Lib\site-packages;");

            //PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PYTHONHOME", EnvironmentVariableTarget.Process);
            //PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);


        }
        #endregion

        #region Private fields
        private IntPtr st;
        #endregion

        #region Properties

        public string PythonPath { get; set; }

        #endregion

        #region Methods
        public override void WorkOnSimulation(Action<dynamic> action)
        {
            using (Py.GIL())
            {
                if (!PythonEngine.IsInitialized)
                {
                    PythonEngine.Initialize();
                    st = PythonEngine.BeginAllowThreads();
                }

                dynamic module = PythonEngine.ImportModule("csTest");
                action(module);
            }

            //PythonEngine.ReleaseLock(gs);
            //PythonEngine.EndAllowThreads(st);
            //PythonEngine.Shutdown();
        }

        public override T WorkOnSimulation<T>(Func<dynamic, T> func)
        {
            using(Py.GIL())
            {
                dynamic module = Py.Import("csTest");
                return func(module);
            }
        }

        public override Task WorkOnSimulationAsync(Action<dynamic> action)
        {
            return Task.Run(() => WorkOnSimulation(action));
        }
        public override Task<T> WorkOnSimulationAsync<T>(Func<dynamic, T> func)
            => Task.Run(() => WorkOnSimulationAsync(func));

        public override void Dispose()
        {
            //PythonEngine.EndAllowThreads(ts);
            //PythonEngine.Shutdown();
        }

        #endregion

    }
}
