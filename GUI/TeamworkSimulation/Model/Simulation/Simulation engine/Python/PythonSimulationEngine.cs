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

        }
        #endregion

        #region Private fields
        private string prevPythonPath;
        private string pythonPath;

        private bool pythonPathChanged;
        #endregion

        #region Properties

        public string PythonPath
        {
            get => pythonPath;
            set
            {
                prevPythonPath = pythonPath;
                pythonPath = value;

                if (pythonPath != null && prevPythonPath != null && !pythonPath.Equals(prevPythonPath))
                    pythonPathChanged = true;
            }
        }

        public string ModuleName { get; set; } = string.Empty;

        #endregion

        #region Methods
        public override void WorkOnSimulation(Action<dynamic> action)
        {
            using (Py.GIL())
            {
                dynamic module = PythonEngine.ImportModule(ModuleName);
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
                dynamic module = PythonEngine.ImportModule(ModuleName);
                return func(module);
            }
        }

        public override Task WorkOnSimulationAsync(Action<dynamic> action)
        {
            return Task.Run(() => WorkOnSimulation(action));
        }
        public override Task<T> WorkOnSimulationAsync<T>(Func<dynamic, T> func)
            => Task.Run(() => WorkOnSimulation(func));

        public void Initialize()
        {
            if (!pythonPathChanged)
                return;

            pythonPathChanged = false;

            string pythonPath = PythonPath;

            Environment.SetEnvironmentVariable("PATH", $@"{pythonPath};" + Environment.GetEnvironmentVariable("PATH"));
            Environment.SetEnvironmentVariable("PYTHONHOME", pythonPath);

            Environment.SetEnvironmentVariable("PYTHONPATH ", $@"{pythonPath}\..\Lib;{pythonPath}\..\Lib\site-packages;");

            PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PYTHONHOME", EnvironmentVariableTarget.Process);
            PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);
        }

        public override void Dispose()
        {
            //PythonEngine.EndAllowThreads(ts);
            //PythonEngine.Shutdown();
        }

        #endregion

    }
}
