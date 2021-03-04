using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class WorkplaceViewModel : ProjectItemViewModel
    {

        #region Constructors

        public WorkplaceViewModel(IWorkplace workplace)
            :base(workplace)
        {
            this.workplace = workplace ?? throw new ArgumentNullException(nameof(workplace));

            teamVMs = new ObservableCollection<TeamViewModel>(workplace.Teams.Select(n =>
                new TeamViewModel(n)));

            TeamVMs = new ReadOnlyObservableCollection<TeamViewModel>(teamVMs);

            workplace.Added += Workplace_Added;
            workplace.Removed += Workplace_Removed;
            workplace.Cleared += Workplace_Cleared;

            foreach (var v in teamVMs)
                AddProjectItem(v);
        }

        #endregion

        #region Private fields

        private readonly IWorkplace workplace;
        private readonly ObservableCollection<TeamViewModel> teamVMs;

        #endregion

        #region Properties

        public ReadOnlyObservableCollection<TeamViewModel> TeamVMs { get; }

        public bool IsRemote
        {
            get => workplace.IsRemote;
            set => SetProperty(() => workplace.IsRemote == value, () => workplace.IsRemote = value);
        }

        #endregion

        #region Methods

        protected void Add()
        {
            workplace.AddTeam();
        }

        protected void Remove(int index)
        {
            workplace.RemoveTeamAt(index);
        }

        protected void Clear()
        {
            workplace.ClearTeams();
        }

        private void Workplace_Added(object sender, DataEventArgs<(int, ITeam)> e)
        {
            TeamViewModel teamVM = new TeamViewModel(e.Value.Item2) { ParentViewModel = this };
            teamVMs.Add(teamVM);
            AddProjectItem(teamVM);
        }

        private void Workplace_Removed(object sender, DataEventArgs<(int, ITeam)> e)
        {
            teamVMs.RemoveAt(e.Value.Item1);
            RemoveProjectItem(e.Value.Item1);
        }

        private void Workplace_Cleared(object sender, EventArgs e)
        {
            teamVMs.Clear();
            ClearProjectItems();
        }

        #endregion

        #region Commands

        private ICommand addTeam;

        public ICommand AddTeam => RelayCommand.Create(ref addTeam, o => Add());

        private ICommand removeTeam;

        public ICommand RemoveTeam => RelayCommand.Create(ref removeTeam, o =>
        {
            if(o is TeamViewModel t)
            {
                int index = teamVMs.IndexOf(t);
                if (index == -1)
                    return;
                Remove(index);
            }
        });

        private ICommand clearTeams;

        public ICommand ClearTeams => RelayCommand.Create(ref clearTeams, o => Clear());

        #endregion

    }
}
