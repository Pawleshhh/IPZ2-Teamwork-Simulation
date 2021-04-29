using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class SimulationPlotResultCollectionViewModel : SimulationResultCollectionViewModel<PlotResultViewModel>
    {

        #region Constructors
        public SimulationPlotResultCollectionViewModel(SimulationPlotResultCollection plotResultCollection, IViewModel parent)
            : base(plotResultCollection, parent)
        {
            this.plotResultCollection = plotResultCollection;
        }
        #endregion

        #region Private fields
        private readonly SimulationPlotResultCollection plotResultCollection;
        #endregion

        #region Properties

        public override string Name => "Plots";


        public PlotModel CurrentPlot { get; private set; }

        #endregion

        #region Methods

        protected override ObservableCollection<PlotResultViewModel> CreateCollection()
        {
            ObservableCollection<PlotResultViewModel> observable = new ObservableCollection<PlotResultViewModel>();
            foreach(var result in resultCollection.Results)
            {
                observable.Add(new PlotResultViewModel((PlotResult)result, this));
            }

            return observable;
        }

        private void SelectPlotModel(PlotModel plt)
        {
            CurrentPlot = plt;
            OnPropertyChanged(nameof(CurrentPlot));
        }

        #endregion

        #region Commands

        private ICommand selectPlot;

        public ICommand SelectPlot => RelayCommand.Create(ref selectPlot, o =>
        {
            if (o is PlotModel plt)
            {
                SelectPlotModel(plt);
            }
        });

        #endregion
    }
}
