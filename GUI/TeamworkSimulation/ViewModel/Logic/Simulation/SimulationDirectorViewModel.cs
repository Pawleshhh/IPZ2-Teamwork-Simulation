using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public class SimulationDirectorViewModel : NotifyPropertyChanges, IViewModel
    {

        #region Constructors
        public SimulationDirectorViewModel(SimulationDirector director, IViewModel parent)
        {
            simulationDirector = director;
            ParentViewModel = parent;

            simulationDirector.ProgressChanged += SimulationDirector_ProgressChanged;
        }

        #endregion

        #region Private fields

        private readonly SimulationDirector simulationDirector;

        #endregion

        #region Properties
        public IViewModel ParentViewModel { get; set; }


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

        public double Progress => simulationDirector.Progress;

        #endregion

        #region Methods

        private void SimulationDirector_ProgressChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Progress));
        }

        #endregion

    }
}
