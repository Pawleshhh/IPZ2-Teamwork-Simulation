using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public static class SimulationResultViewModelFactory
    {

        public static SimulationResultViewModel CreateSimulationResultVM(ISimulationResult simulationResult, IViewModel parent)
        {
            if(simulationResult is SimulationResultCollection resultCollection)
            {
                return new SimulationResultCollectionViewModel(resultCollection, parent);
            }
            else
            {
                switch (simulationResult)
                {
                    case PlotResult plt:
                        return new PlotResultViewModel(plt, parent);
                    case StatisticsResult st:
                        return new StatisticsResultViewModel(st, parent);
                    default:
                        return null;
                }
            }
        }

    }
}
