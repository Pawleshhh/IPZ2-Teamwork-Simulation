using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TeamworkSimulation.Model.Simulation
{
    public class MultiThreadedGILState : IDisposable
    {
        public MultiThreadedGILState()
        {
            Monitor.Enter(_synchronizationObject);
            _ts = PythonEngine.BeginAllowThreads();
            _gs = PythonEngine.AcquireLock();

        }

        IntPtr _ts, _gs;

        public void Dispose()
        {
            PythonEngine.ReleaseLock(_gs);
            PythonEngine.EndAllowThreads(_ts);
            Monitor.Exit(_synchronizationObject);
            GC.SuppressFinalize(this);
        }

        ~MultiThreadedGILState()
        {
            Dispose();
        }

        static object _synchronizationObject = new object();
    }
}
