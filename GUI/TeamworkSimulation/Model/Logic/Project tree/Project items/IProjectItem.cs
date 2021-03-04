using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    public interface IProjectItem
    {
        #region Properties

        string ItemName { get; set; }

        Color Color { get; }

        IReadOnlyCollection<IProjectItem> GetProjectItems();

        #endregion

        #region Events

        event EventHandler<ProjectItemChanged> ItemChanged;

        #endregion

        #region Methods

        void AddProjectItem(IProjectItem projectItem);
        void RemoveProjectItem(IProjectItem projectItem);
        void ClearProjectItems();

        bool CanContainProjectItem(IProjectItem projectItem);

        void ApplyColor();

        #endregion
    }

    public class ProjectItemChanged : EventArgs
    {

        IProjectItem SourceItem { get; }

        public bool Handle { get; set; }

        public ProjectItemChanged(IProjectItem source)
        {
            SourceItem = source;
        }
    }
}
