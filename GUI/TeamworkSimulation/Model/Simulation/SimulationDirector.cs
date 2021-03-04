using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkSimulation.Model.Simulation
{
    public abstract class SimulationDirector
    {

        #region Constructors

        protected SimulationDirector()
        {
            Engine = CreateEngine();
        }

        #endregion

        #region Properties

        public SimulationEngine Engine { get; }

        public bool IsWorking { get; private set; }

        #endregion

        #region Events

        public event EventHandler Started;
        public event EventHandler Stopped;

        protected virtual void OnStarted()
        {
            IsWorking = true;
            Started?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnStopped()
        {
            IsWorking = false;
            Stopped?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Methods

        public async void StartSimulation(ModelItem root)
        {
            var attributes = GetAllAttributes(root);

            OnStarted();
            await BeginSimulation(attributes);
            OnStopped();
        }

        protected abstract Task BeginSimulation(List<int[]> attr);

        protected abstract SimulationEngine CreateEngine();

        protected virtual List<int[]> GetAllAttributes(ModelItem root)
        {
            List<int[]> attributes = new List<int[]>();

            Stack<ModelItem> stack = new Stack<ModelItem>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                ModelItem current = stack.Pop();

                int[] attr = current.SimulationModel.GetAttributes();
                if (attr.Length > 0)
                    attributes.Add(attr);

                var modelItems = ((IProjectItem)current).GetProjectItems().Where(n => n is ModelItem)
                    .Select(m => (ModelItem)m);

                foreach (var item in modelItems)
                    stack.Push(item);

            }

            return attributes;
        }

        #endregion

    }
}
