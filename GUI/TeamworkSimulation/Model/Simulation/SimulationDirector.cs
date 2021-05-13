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

            iterations = MinimumIterations;
            simulationCount = MinimumSimulationCount;
        }

        #endregion

        #region Private fields

        private int iterations;
        private int simulationCount;

        #endregion

        #region Properties

        public SimulationResultDirector ResultDirector { get; private set; }

        public SimulationEngine Engine { get; }

        public bool IsWorking { get; private set; }

        public int MaximumIterations { get; } = 100;
        public int MinimumIterations { get; } = 10;

        public int Iterations
        {
            get => iterations;
            set
            {
                if (MinimumIterations > value && value > MaximumIterations)
                    throw new ArgumentException(nameof(value));

                iterations = value;
            }
        }

        public int MaximumSimulationCount { get; } = 10;
        public int MinimumSimulationCount { get; } = 1;
        public int SimulationCount
        {
            get => simulationCount;
            set
            {
                if (MinimumSimulationCount > value && value > MaximumSimulationCount)
                    throw new ArgumentException(nameof(value));

                simulationCount = value;
            }
        }

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

            List<double[][][]> allResults = new List<double[][][]>();

            for (int i = 0; i < SimulationCount; i++)
            {
                double[][][] simResult = await BeginSimulation<double[][][]>(attributes);
                allResults.Add(simResult);
            }
            SetResults(allResults);

            OnStopped();
        }

        protected abstract Task BeginSimulation(List<int[]> attr);

        protected abstract Task<T> BeginSimulation<T>(List<int[]> attr);

        protected abstract SimulationEngine CreateEngine();

        protected virtual List<int[]> GetAllAttributes(ModelItem root)
        {
            List<int[]> attributes = new List<int[]>();

            attributes.Add(new int[] { Iterations });

            Stack<ModelItem> stack = new Stack<ModelItem>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                ModelItem current = stack.Pop();

                if (current.UseModel)
                {
                    int[] attr = current.SimulationModel.GetAttributes();
                    if (attr.Length > 0)
                        attributes.Add(attr);

                    var modelItems = ((IProjectItem)current).GetProjectItems().Where(n => n is ModelItem)
                        .Select(m => (ModelItem)m);

                    foreach (var item in modelItems)
                        stack.Push(item);
                }
            }

            return attributes;
        }

        protected virtual void SetResults(List<double[][][]> allSimResults)
        {

            List<ISimulationResult> resultCollections = new List<ISimulationResult>();

            int i = 1;
            foreach (var simResult in allSimResults)
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

                resultCollections.Add(new SimulationResultCollection(new List<PlotResult>()
                    {
                        new PlotResult(result[0], "Tiredness"),
                        new PlotResult(result[1], "Work conditions"),
                        new PlotResult(result[2], "Team effectiveness"),
                        new PlotResult(result[3], "Comfort"),
                        new PlotResult(result[4], "Team Study Comfort"),
                        new PlotResult(result[5], "Help"),
                        new PlotResult(result[6], "Self improvement"),
                        new PlotResult(result[7], "Communication"),
                    }, $"Simulation {i}"));

                i++;
            }

            ResultDirector = new SimulationResultDirector(resultCollections);
        }

        #endregion

    }
}
