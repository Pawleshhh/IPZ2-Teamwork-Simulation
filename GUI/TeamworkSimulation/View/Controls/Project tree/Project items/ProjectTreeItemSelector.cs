using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class ProjectTreeItemSelector : DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            if (item is ProjectItemViewModel projectItemVM)
            {
                FrameworkElement element = container as FrameworkElement;
                switch (projectItemVM)
                {
                    case WorkplaceViewModel _:
                        return element.FindResource("workplaceItemTemplate") as DataTemplate;
                    case TeamViewModel _:
                        return element.FindResource("teamItemTemplate") as DataTemplate;
                    case TeamMemberViewModel _:
                        return element.FindResource("teamMemberItemTemplate") as DataTemplate;
                    default:
                        return element.FindResource("projectItemTemplate") as DataTemplate;
                }
            }

            return null;
        }

    }
}
