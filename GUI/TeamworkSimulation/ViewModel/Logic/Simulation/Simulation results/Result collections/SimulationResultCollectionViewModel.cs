using Microsoft.Scripting.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows.Input;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public class SimulationResultCollectionViewModel : SimulationResultViewModel
    {

        #region Constructors
        public SimulationResultCollectionViewModel(SimulationResultCollection resultCollection, IViewModel parent)
            : base(resultCollection, parent)
        {
            this.resultCollection = resultCollection;
            ParentViewModel = parent;

            simulationResultVMs = new ObservableCollection<SimulationResultViewModel>(
                resultCollection.Result.Select(n => SimulationResultViewModelFactory.CreateSimulationResultVM(n, this)));
            SimulationResultVMs = new ReadOnlyObservableCollection<SimulationResultViewModel>(simulationResultVMs);

            if (SimulationResultVMs.Count > 0)
                SetSelectedResult(SimulationResultVMs[0]);
        }
        #endregion

        #region Private fields

        protected readonly SimulationResultCollection resultCollection;
        private ObservableCollection<SimulationResultViewModel> simulationResultVMs;

        #endregion

        #region Properties
        public ReadOnlyObservableCollection<SimulationResultViewModel> SimulationResultVMs { get; }

        public SimulationResultViewModel SelectedResult { get; private set; }

        #endregion

        #region Methods

        private void SetSelectedResult(SimulationResultViewModel resultVM)
        {
            SelectedResult = resultVM;
            OnPropertyChanged(nameof(SelectedResult));
        }

        #endregion

        #region Commands

        private ICommand selectResult;

        public ICommand SelectResult => RelayCommand.Create(ref selectResult, o =>
        {
            if (o is SimulationResultViewModel r)
            {
                SetSelectedResult(r);
            }
        });

        #endregion

    }
}
