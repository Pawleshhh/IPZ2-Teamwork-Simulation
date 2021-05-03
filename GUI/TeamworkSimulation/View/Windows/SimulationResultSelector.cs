﻿using System;
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

            if (item is ISimulationResultCollectionViewModel simResultCollVM)
            {
                switch (simResultCollVM)
                {
                    case SimulationPlotResultCollectionViewModel _:
                        return element.FindResource("simulationPlotResultTemplate") as DataTemplate;
                }
            }

            return null;
        }

    }
}
