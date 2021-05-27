using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamworkSimulation.Utility;

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

        private double progress;

        private readonly SimulationResultInterpreter resultInterpreter = new SimulationResultInterpreter();

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

        public bool KeepPreviousResults { get; set; }

        public double Progress
        {
            get => progress;
            private set
            {
                progress = value;
                OnProgressChanged();
            }
        }

        #endregion

        #region Events

        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler ProgressChanged;

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
        protected virtual void OnProgressChanged()
        {
            ProgressChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Methods

        public async void StartSimulation(ModelItem root)
        {
            var attributes = GetAllAttributes(root);

            Progress = 0;
            OnStarted();

            List<double[][][]> allResults = new List<double[][][]>();

            for (int i = 0; i < SimulationCount; i++)
            {
                double[][][] simResult = await BeginSimulation<double[][][]>(attributes);
                allResults.Add(simResult);

                Progress = (double)(i + 1) / SimulationCount;
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

            List<ISimulationResult> resultCollections;

            if (KeepPreviousResults && ResultDirector != null)
            {
                resultCollections = new List<ISimulationResult>(ResultDirector.Results);
                resultCollections.RemoveAt(resultCollections.Count - 1);
            }
            else
            {
                resultCollections = new List<ISimulationResult>();
                resultInterpreter.Clear();
            }

            resultCollections.AddRange(resultInterpreter.InterpretResults(allSimResults));

            ResultDirector = new SimulationResultDirector(resultCollections);
        }

        private StatisticsResultData GetStatisticsResultData(double[] values, string name)
        {
            return new StatisticsResultData(
                Statistics.Mean(values),
                Statistics.Median(values),
                Statistics.StandardDeviation(values),
                name);
        }

        #endregion

    }
}
