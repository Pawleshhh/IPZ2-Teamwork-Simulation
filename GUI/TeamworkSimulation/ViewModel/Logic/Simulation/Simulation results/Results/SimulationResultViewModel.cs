using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public abstract class SimulationResultViewModel : NotifyPropertyChanges, IViewModel
    {

        #region Constructors
        public SimulationResultViewModel(ISimulationResult simulationResult, IViewModel parent)
        {
            this.simulationResult = simulationResult;
            ParentViewModel = parent;
        }
        #endregion

        #region Private fields
        private ISimulationResult simulationResult;
        #endregion

        #region Properties

        public string Name => simulationResult.Name;

        public IViewModel ParentViewModel { get; set; }
        #endregion

    }
}
