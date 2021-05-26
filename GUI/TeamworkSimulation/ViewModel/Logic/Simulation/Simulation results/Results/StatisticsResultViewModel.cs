using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public class StatisticsResultViewModel : SimulationResultViewModel
    {

        #region Constructors
        public StatisticsResultViewModel(StatisticsResult statisticsResult, IViewModel parent) : base(statisticsResult, parent)
        {
            StatisticsDataCollection = new ObservableCollection<StatisticsResultData>(statisticsResult.Result);
        }
        #endregion

        #region Properties

        public ObservableCollection<StatisticsResultData> StatisticsDataCollection { get; }

        #endregion

    }
}
