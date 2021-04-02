using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation.View
{
    public class ProjectTreeContextMenuSelector
    {
        public ContextMenu SelectContextMenu(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            switch(item)
            {
                case WorkplaceViewModel _:
                    return element.FindResource("workplaceContextMenu") as ContextMenu;
                case TeamViewModel _:
                    return element.FindResource("teamContextMenu") as ContextMenu;
                case TeamMemberViewModel _:
                    return element.FindResource("teamMemberContextMenu") as ContextMenu;
            }

            return null;
        }

    }
}
