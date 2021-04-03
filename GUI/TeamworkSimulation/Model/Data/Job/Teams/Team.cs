using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using TeamworkSimulation.Utility;

namespace TeamworkSimulation.Model
{
    [DataContract]
    [KnownType(typeof(Worker))]
    [KnownType(typeof(Student))]
    public class Team<T> : ModelItem, ITeam
        where T : ITeamMember, new()
    {

        #region Constructors

        public Team()
        {
            ItemName = "Team";
        }

        #endregion

        #region Private fields

        [DataMember]
        private List<T> teamMembers = new List<T>();

        #endregion

        #region Properties

        public IReadOnlyList<T> TeamMembers => teamMembers;

        IReadOnlyList<ITeamMember> ITeam.TeamMembers => (IReadOnlyList<ITeamMember>)TeamMembers;

        #endregion

        #region Events

        public event EventHandler<DataEventArgs<(int, ITeamMember)>> Added;
        public event EventHandler<DataEventArgs<(int, ITeamMember)>> Removed;
        public event EventHandler Cleared;

        protected void OnAdded(int index, ITeamMember teamMember)
        {
            Added?.Invoke(this, new DataEventArgs<(int, ITeamMember)>((index, teamMember)));
            InvokeItemChangedEvent();
        }
        protected void OnRemoved(int index, ITeamMember teamMember)
        {
            Removed?.Invoke(this, new DataEventArgs<(int, ITeamMember)>((index, teamMember)));
            InvokeItemChangedEvent();
        }
        protected void OnClear()
        {
            Cleared?.Invoke(this, EventArgs.Empty);
            InvokeItemChangedEvent();
        }
        #endregion

        #region Methods

        void ITeam.AddTeamMember(ITeamMember teamMember)
            => AddTeamMember((T)teamMember);
        void ITeam.RemoveTeamMember(ITeamMember teamMember)
            => RemoveTeamMember((T)teamMember);

        public void AddTeamMember()
            => AddTeamMember(new T());
        public void CopyTeamMember(int index)
        {
            var teamMember = (T)teamMembers[index].Copy();
            teamMember.Color.SelectedColor = teamMembers[index].Color.SelectedColor;

            AddTeamMember(teamMember, index + 1);
        }
        public void AddTeamMember(T teamMember, int index = -1)
        {
            if (index == -1)
                teamMembers.Add(teamMember);
            else
                teamMembers.Insert(index, teamMember);
            SubscribeProjectItem(teamMember);

            OnAdded(index > -1 ? index : teamMembers.Count - 1, teamMember);
        }
        public void RemoveTeamMember(T teamMember)
        {
            int index = teamMembers.IndexOf(teamMember);
            if (index == -1)
                return;

            RemoveTeamMemberAt(index);
            UnsubscribeProjectItem(teamMember);
        }
        public void RemoveTeamMemberAt(int index)
        {
            T teamMember = teamMembers[index];
            teamMembers.RemoveAt(index);
            UnsubscribeProjectItem(teamMember);
            OnRemoved(index, teamMember);
        }
        public void ClearTeamMembers()
        {
            foreach(var item in teamMembers)
                UnsubscribeProjectItem(item);

            teamMembers.Clear();
            OnClear();
        }

        public virtual ITeam Copy()
        {
            ITeam team = new Team<T>();

            foreach (var teamMember in teamMembers)
                team.AddTeamMember(teamMember.Copy());

            return team;
        }

        #endregion

        #region ProjectItem

        protected override void AddProjectItem(IProjectItem projectItem)
            => AddTeamMember((T)projectItem);
        protected override void RemoveProjectItem(IProjectItem projectItem)
            => RemoveProjectItem((T)projectItem);
        protected override void ClearProjectItems()
            => ClearTeamMembers();

        protected override bool CanContainProjectItem(IProjectItem projectItem)
            => projectItem is T;

        protected override IReadOnlyCollection<IProjectItem> GetProjectItems()
            => (IReadOnlyCollection<IProjectItem>)teamMembers;

        #endregion

    }
}
