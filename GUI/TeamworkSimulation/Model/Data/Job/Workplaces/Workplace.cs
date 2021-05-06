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
    public class Workplace<T> : ModelItem, IWorkplace
        where T : ITeam, new()
    {

        #region Private fields

        [DataMember]
        private List<T> teams = new List<T>();

        [DataMember]
        private int iterations = 2;

        [DataMember]
        private bool isRemote;

        #endregion

        #region Properties

        public IReadOnlyList<T> Teams => teams;
        IReadOnlyList<ITeam> IWorkplace.Teams => (IReadOnlyList<ITeam>)Teams;

        public int TotalTeamMemberCount
        {
            get
            {
                int count = 0;
                foreach (var team in teams)
                    count += team.TeamMembers.Count;

                return count;
            }
        }

        public int MaximumIterations { get; } = 10;
        public int MinimumIterations { get; } = 2;

        public int Iterations
        {
            get => iterations;
            set
            {
                if (iterations <= 0)
                    throw new ArgumentException(nameof(value));

                iterations = value;
                InvokeItemChangedEvent();
            }
        }

        public IErgonomy Ergonomy { get; set; }
        public ITechnology Technology { get; set; }

        public bool IsRemote
        {
            get => isRemote;
            set
            {
                isRemote = value;
                InvokeItemChangedEvent();
            }
        }

        #endregion

        #region Events

        public event EventHandler<DataEventArgs<(int, ITeam)>> Added;
        public event EventHandler<DataEventArgs<(int, ITeam)>> Removed;
        public event EventHandler Cleared;

        protected void OnAdded(int index, ITeam team)
        {
            Added?.Invoke(this, new DataEventArgs<(int, ITeam)>((index, team)));
            InvokeItemChangedEvent();
        }
        protected void OnRemoved(int index, ITeam team)
        {
            Removed?.Invoke(this, new DataEventArgs<(int, ITeam)>((index, team)));
            InvokeItemChangedEvent();
        }
        protected void OnCleared()
        {
            Cleared?.Invoke(this, EventArgs.Empty);
            InvokeItemChangedEvent();
        }
        #endregion

        #region Methods

        void IWorkplace.AddTeam(ITeam team)
            => AddTeam((T)team);
        void IWorkplace.RemoveTeam(ITeam team)
            => RemoveTeam((T)team);

        public void AddTeam()
            => AddTeam(new T());
        public void CopyTeam(int index)
        {
            var team = (T)teams[index].Copy();
            team.Color.SelectedColor = teams[index].Color.SelectedColor;

            AddTeam(team, index + 1);
        }
        public void AddTeam(T team, int index = -1)
        {
            if (index == -1)
                teams.Add(team);
            else
                teams.Insert(index, team);

            SubscribeProjectItem(team);

            OnAdded(index > -1 ? index : teams.Count - 1, team);
        }
        public void RemoveTeam(T team)
        {
            int index = teams.IndexOf(team);
            if (index == -1)
                return;

            RemoveTeamAt(index);
            UnsubscribeProjectItem(team);
        }
        public void RemoveTeamAt(int index)
        {
            T team = teams[index];
            teams.RemoveAt(index);
            UnsubscribeProjectItem(team);

            OnRemoved(index, team);
        }
        public void ClearTeams()
        {
            foreach (var item in teams)
                UnsubscribeProjectItem(item);

            teams.Clear();
            OnCleared();
        }

        #endregion

        #region ProjectItem

        protected override void AddProjectItem(IProjectItem projectItem)
            => AddTeam((T)projectItem);
        protected override void RemoveProjectItem(IProjectItem projectItem)
            => RemoveTeam((T)projectItem);
        protected override void ClearProjectItems()
            => ClearTeams();

        protected override bool CanContainProjectItem(IProjectItem projectItem)
            => projectItem is T;

        protected override IReadOnlyCollection<IProjectItem> GetProjectItems()
            => (IReadOnlyCollection<IProjectItem>)teams;

        #endregion

    }
}
