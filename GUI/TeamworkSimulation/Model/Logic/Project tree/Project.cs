using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TeamworkSimulation.Model
{
    [DataContract]
    [KnownType(typeof(Company))]
    [KnownType(typeof(University))]
    public class Project : ModelItem
    {

        #region Constructors
        public Project()
        {
            WorkplaceTemplateBuilder = new WorkplaceTemplateBuilder();
        }
        #endregion

        #region Private fields

        [DataMember]
        private List<IWorkplace> workplaces = new List<IWorkplace>();

        #endregion

        #region Events
        public event EventHandler<DataEventArgs<(int, IWorkplace)>> Added;
        public event EventHandler<DataEventArgs<(int, IWorkplace)>> Removed;
        public event EventHandler Cleared;

        protected void OnAdded(int index, IWorkplace workplace)
        {
            Added?.Invoke(this, new DataEventArgs<(int, IWorkplace)>((index, workplace)));
            InvokeItemChangedEvent();
            UnsavedChanges = true;
        }
        protected void OnRemoved(int index, IWorkplace workplace)
        {
            Removed?.Invoke(this, new DataEventArgs<(int, IWorkplace)>((index, workplace)));
            InvokeItemChangedEvent();
            UnsavedChanges = true;
        }
        protected void OnClear()
        {
            Cleared?.Invoke(this, EventArgs.Empty);
            InvokeItemChangedEvent();
            UnsavedChanges = true;
        }

        #endregion

        #region Properties

        [DataMember(Name = "ProjectName")]
        public string ProjectName { get; set; }

        public IReadOnlyList<IWorkplace> Workplaces => workplaces;

        [DataMember]
        public int CurrentWorkplace { get; set; }

        [DataMember]
        public WorkplaceTemplateBuilder WorkplaceTemplateBuilder { get; private set; }

        public bool UnsavedChanges { get; set; }

        #endregion

        #region Methods

        public void AddWorkplace()
            => AddWorkplace(WorkplaceTemplateBuilder.BuildWorkplace());
        public void AddWorkplace(IWorkplace workplace)
        {
            workplaces.Add(workplace);
            SubscribeProjectItem(workplace);

            OnAdded(workplaces.Count - 1, workplace);
        }
        public void RemoveWorkplace(IWorkplace workplace)
        {
            int index = workplaces.IndexOf(workplace);
            if (index == -1)
                return;
            RemoveWorkplaceAt(index);
            UnsubscribeProjectItem(workplace);
        }
        public void RemoveWorkplaceAt(int index)
        {
            IWorkplace workplace = workplaces[index];
            workplaces.RemoveAt(index);
            UnsubscribeProjectItem(workplace);

            OnRemoved(index, workplace);
        }
        public void ClearWorkplaces()
        {
            foreach (var item in workplaces)
                UnsubscribeProjectItem(item);

            workplaces.Clear();
            OnClear();
        }

        #endregion

        #region ProjectItem

        protected override void OnProjectItemChanged(ProjectItemChanged e)
        {
            UnsavedChanges = true;

            e.Handle = true;
        }

        protected override void AddProjectItem(IProjectItem projectItem)
            => AddWorkplace((IWorkplace)projectItem);
        protected override void RemoveProjectItem(IProjectItem projectItem)
            => RemoveWorkplace((IWorkplace)projectItem);
        protected override void ClearProjectItems()
            => ClearWorkplaces();

        protected override bool CanContainProjectItem(IProjectItem projectItem)
            => projectItem is IWorkplace;

        protected override IReadOnlyCollection<IProjectItem> GetProjectItems()
            => workplaces;

        #endregion
    }
}
