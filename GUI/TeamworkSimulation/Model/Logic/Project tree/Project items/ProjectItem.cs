using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    [DataContract]
    [KnownType(typeof(Project))]
    [KnownType(typeof(ModelItem))]
    public abstract class ProjectItem : IProjectItem
    {

        #region Constructors

        public ProjectItem()
        {
            Color.SelectedColorChanged += Color_SelectedColorChanged;
        }

        #endregion

        #region IProjectItem members

        [DataMember(Name = "Name")]
        public string ItemName { get; set; }

        [DataMember(Name = "Color")]
        public Color Color { get; private set; } = new Color();

        public event EventHandler<ProjectItemChanged> ItemChanged;

        void IProjectItem.AddProjectItem(IProjectItem projectItem)
        {
            AddProjectItem(projectItem);
        }

        void IProjectItem.RemoveProjectItem(IProjectItem projectItem)
        {
            RemoveProjectItem(projectItem);
        }
        void IProjectItem.ClearProjectItems()
        {
            ClearProjectItems();
        }

        bool IProjectItem.CanContainProjectItem(IProjectItem projectItem)
        {
            return CanContainProjectItem(projectItem);
        }

        IReadOnlyCollection<IProjectItem> IProjectItem.GetProjectItems()
        {
            return GetProjectItems();
        }

        #endregion

        #region Method

        public void ApplyColor()
        {
            foreach (var item in GetProjectItems())
                item.Color.SelectedColor = Color.SelectedColor;
        }

        protected virtual void OnProjectItemChanged(ProjectItemChanged e) { }

        protected void InvokeItemChangedEvent(ProjectItemChanged e)
            => ItemChanged?.Invoke(this, e);

        protected void InvokeItemChangedEvent()
            => ItemChanged?.Invoke(this, new ProjectItemChanged(this));

        protected void SubscribeProjectItem(IProjectItem projectItem)
            => projectItem.ItemChanged += ProjectItem_ItemChanged;

        protected void UnsubscribeProjectItem(IProjectItem projectItem)
            => projectItem.ItemChanged -= ProjectItem_ItemChanged;

        protected bool SetProperty(Func<bool> equal, Action set)
        {
            if (equal())
                return false;

            set();

            return true;
        }

        protected abstract void AddProjectItem(IProjectItem projectItem);
        protected abstract void RemoveProjectItem(IProjectItem projectItem);
        protected abstract void ClearProjectItems();

        protected abstract bool CanContainProjectItem(IProjectItem projectItem);

        protected abstract IReadOnlyCollection<IProjectItem> GetProjectItems();

        private void ProjectItem_ItemChanged(object sender, ProjectItemChanged e)
        {
            OnProjectItemChanged(e);

            if (!e.Handle)
                InvokeItemChangedEvent(e);
        }

        private void Color_SelectedColorChanged(object sender, DataEventArgs<string> e)
        {
            InvokeItemChangedEvent();
        }

        #endregion
    }

}
