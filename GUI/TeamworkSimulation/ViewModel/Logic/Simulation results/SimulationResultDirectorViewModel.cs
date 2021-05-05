using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class SimulationResultDirectorViewModel : NotifyPropertyChanges, IViewModel
    {

        #region Constructors

        public SimulationResultDirectorViewModel(SimulationResultDirector director, IViewModel parent)
        {
            this.director = director;
            ParentViewModel = parent;

            resultCollectionVMs = new ObservableCollection<SimulationResultViewModel>(
                director.Results.Select(n => SimulationResultViewModelFactory.CreateSimulationResultVM(n, this)));

            Results = new ReadOnlyObservableCollection<SimulationResultViewModel>(resultCollectionVMs);
        }
        #endregion

        #region Private fields

        private SimulationResultDirector director;
        private ObservableCollection<SimulationResultViewModel> resultCollectionVMs;

        #endregion

        #region Properties
        public IViewModel ParentViewModel { get; set; }

        public ReadOnlyObservableCollection<SimulationResultViewModel> Results { get; }

        #endregion

        #region Methods

        #endregion

    }
}
