using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            string pythonPath = @"C:\Program Files\Python37";

            Environment.SetEnvironmentVariable("PATH", $@"{pythonPath};" + Environment.GetEnvironmentVariable("PATH"));
            Environment.SetEnvironmentVariable("PYTHONHOME", pythonPath);

            Environment.SetEnvironmentVariable("PYTHONPATH ", $@"{pythonPath}\..\Lib;{pythonPath}\..\Lib\site-packages;");

            PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PYTHONHOME", EnvironmentVariableTarget.Process);
            PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);

            //var pathToVirtualEnv = @"C:\ProgramData\Miniconda3";
            ////var pathToVirtualEnv = @"C:\Users\1\AppData\Local\Programs\Python\Python37";
            ////var pathToVirtualEnv = @"C:\Program Files\Python39";

            //Environment.SetEnvironmentVariable("PATH", pathToVirtualEnv, EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("PYTHONHOME", pathToVirtualEnv, EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("PYTHONPATH", $"{pathToVirtualEnv}\\Lib\\site-packages;{pathToVirtualEnv}\\Lib", EnvironmentVariableTarget.Process);

            //PythonEngine.PythonHome = pathToVirtualEnv;
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
                dynamic module = PythonEngine.ImportModule("csTest");
                dynamic result = module.StartSimulation(1);

                var list = (double[][][])result;
            }

            //using (Py.GIL())
            //{
            //    dynamic module = PythonEngine.ImportModule("numpy");
            //}
        }

        public override T WorkOnSimulation<T>(Func<dynamic, T> func)
        {
            using(Py.GIL())
            {
                dynamic module = PythonEngine.ImportModule("csTest");
                return func(module);
            }
        }

        public override Task WorkOnSimulationAsync(Action<dynamic> action)
        {
            return Task.Run(() => WorkOnSimulation(action));
        }
        public override Task<T> WorkOnSimulationAsync<T>(Func<dynamic, T> func)
            => Task.Run(() => WorkOnSimulation(func));

        public override void Dispose()
        {
            //PythonEngine.EndAllowThreads(ts);
            //PythonEngine.Shutdown();
        }

        #endregion

    }
}
