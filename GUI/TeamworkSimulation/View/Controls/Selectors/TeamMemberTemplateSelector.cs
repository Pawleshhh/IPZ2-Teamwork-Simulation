using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class TeamMemberTemplateSelector : DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if(item is TeamMemberViewModel teamMemberVM)
            {
                switch(teamMemberVM)
                {
                    case WorkerViewModel _:
                        return element.FindResource("WorkerTemplate") as DataTemplate;
                    case StudentViewModel _:
                        return element.FindResource("StudentTemplate") as DataTemplate;
                }
            }

            return null;
        }

    }
}
