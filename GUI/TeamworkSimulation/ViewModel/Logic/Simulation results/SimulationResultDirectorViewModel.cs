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

            resultCollectionVMs = new ObservableCollection<ISimulationResultCollectionViewModel>(
                director.ResultCollections.Select(n => SimulationResultCollectionViewModelFactory.CreateSimulationResultCollectionVM(n, this)));

            ResultCollectionVMs = new ReadOnlyObservableCollection<ISimulationResultCollectionViewModel>(resultCollectionVMs);
        }
        #endregion

        #region Private fields

        private SimulationResultDirector director;
        private ObservableCollection<ISimulationResultCollectionViewModel> resultCollectionVMs;

        #endregion

        #region Properties
        public IViewModel ParentViewModel { get; set; }

        public ReadOnlyObservableCollection<ISimulationResultCollectionViewModel> ResultCollectionVMs { get; }

        #endregion

        #region Methods

        #endregion

    }
}
