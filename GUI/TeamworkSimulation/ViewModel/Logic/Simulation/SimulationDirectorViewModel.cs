using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public class SimulationDirectorViewModel : NotifyPropertyChanges, IViewModel
    {

        #region Constructors
        public SimulationDirectorViewModel(SimulationDirector director, IFileService fileService, IViewModel parent)
        {
            simulationDirector = director;
            ParentViewModel = parent;

            EngineVM = GetSimulationEngineViewModel(director.Engine, fileService);

            simulationDirector.ProgressChanged += SimulationDirector_ProgressChanged;
        }

        #endregion

        #region Private fields

        private readonly SimulationDirector simulationDirector;

        #endregion

        #region Properties
        public IViewModel ParentViewModel { get; set; }

        public IViewModel EngineVM { get; }

        public int Iterations
        {
            get => simulationDirector.Iterations;
            set => SetProperty(() => simulationDirector.Iterations == value, () => simulationDirector.Iterations = value);
        }

        public int MaximumIterations => simulationDirector.MaximumIterations;
        public int MinimumIterations => simulationDirector.MinimumIterations;

        public int SimulationCount
        {
            get => simulationDirector.SimulationCount;
            set => SetProperty(() => simulationDirector.SimulationCount == value, () => simulationDirector.SimulationCount = value);
        }

        public int MaximumSimulationCount => simulationDirector.MaximumSimulationCount;
        public int MinimumSimulationCount => simulationDirector.MinimumSimulationCount;

        public bool KeepPreviousResults
        {
            get => simulationDirector.KeepPreviousResults;
            set => SetProperty(() => simulationDirector.KeepPreviousResults == value, () => simulationDirector.KeepPreviousResults = value);
        }

        public int MaximumLeadingArgument => simulationDirector.MaximumLeadingArgument;
        public int MinimumLeadingArgument => simulationDirector.MinimumLeadingArgument;
        public int LeadingArgument
        {
            get => simulationDirector.LeadingArgument;
            set => SetProperty(() => simulationDirector.LeadingArgument == value, () => simulationDirector.LeadingArgument = value);
        }


        public double Progress => simulationDirector.Progress;

        #endregion

        #region Methods

        private void SimulationDirector_ProgressChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Progress));
        }

        private IViewModel GetSimulationEngineViewModel(SimulationEngine engine, IFileService fileService)
        {
            switch(engine)
            {
                case PythonSimulationEngine pyEngine:
                    return new PythonSimulationEngineViewModel(pyEngine, fileService);
            }

            return null;
        }

        #endregion

    }
}
