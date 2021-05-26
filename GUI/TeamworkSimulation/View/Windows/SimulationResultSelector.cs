using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class SimulationResultSelector : DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (item is SimulationResultViewModel simResultCollVM)
            {
                switch (simResultCollVM)
                {
                    case SimulationResultCollectionViewModel _:
                        return element.FindResource("simulationResultCollectionTemplate") as DataTemplate;
                    case PlotResultViewModel _:
                        return element.FindResource("simulationPlotResultTemplate") as DataTemplate;
                    case StatisticsResultViewModel _:
                        return element.FindResource("simulationStatisticsResultTemplate") as DataTemplate;
                }
            }

            return null;
        }

    }
}
