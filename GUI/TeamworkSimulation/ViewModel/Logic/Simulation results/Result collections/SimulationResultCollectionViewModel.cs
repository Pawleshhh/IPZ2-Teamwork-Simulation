using Microsoft.Scripting.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public abstract class SimulationResultCollectionViewModel<T> : NotifyPropertyChanges, ISimulationResultCollectionViewModel
        where T : SimulationResultViewModel
    {

        #region Constructors
        public SimulationResultCollectionViewModel(ISimulationResultCollection resultCollection, IViewModel parent)
        {
            this.resultCollection = resultCollection;
            ParentViewModel = parent;

            simulationResultVMs = CreateCollection();
            SimulationResultVMs = new ReadOnlyObservableCollection<T>(simulationResultVMs);
        }
        #endregion

        #region Private fields
        protected readonly ISimulationResultCollection resultCollection;
        private ObservableCollection<T> simulationResultVMs;

        #endregion

        #region Properties
        public IViewModel ParentViewModel { get; set; }

        public abstract string Name { get; }

        public ReadOnlyObservableCollection<T> SimulationResultVMs { get; }
        IReadOnlyList<SimulationResultViewModel> ISimulationResultCollectionViewModel.SimulationResultVMs => SimulationResultVMs;

        #endregion

        #region Methods

        protected abstract ObservableCollection<T> CreateCollection();

        #endregion
    }
}
