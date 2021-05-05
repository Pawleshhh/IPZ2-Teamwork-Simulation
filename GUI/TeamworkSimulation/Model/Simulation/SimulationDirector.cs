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

        public SimulationResultDirector ResultDirector { get; private set; }

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

            double[][][] simResult = await BeginSimulation<double[][][]>(attributes);
            SetResults(simResult);

            OnStopped();
        }

        protected abstract Task BeginSimulation(List<int[]> attr);

        protected abstract Task<T> BeginSimulation<T>(List<int[]> attr);

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

        protected virtual void SetResults(double[][][] simResult)
        {
            List<List<double[]>> result = new List<List<double[]>>();

            for (int x = 0; x < simResult.Length; x++)
            {
                result.Add(new List<double[]>());
                for (int y = 0; y < simResult[x].Length; y++)
                {
                    result[x].Add(simResult[x][y]);
                }
            }

            List<ISimulationResult> resultCollections = new List<ISimulationResult>()
            {
                new SimulationResultCollection(new List<PlotResult>()
                {
                    new PlotResult(result[0], "plot 1"),
                    new PlotResult(result[1], "plot 2"),
                    new PlotResult(result[2], "plot 3"),
                    new PlotResult(result[3], "plot 4"),
                    new PlotResult(result[4], "plot 5"),
                    new PlotResult(result[5], "plot 6"),
                    new PlotResult(result[6], "plot 7"),
                    new PlotResult(result[7], "plot 8"),
                }, "Plots")
            };

            ResultDirector = new SimulationResultDirector(resultCollections);
        }

        #endregion

    }
}
