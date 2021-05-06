using System;
using System.Collections;
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

        public WorkplaceViewModel(IWorkplace workplace, IViewModel parent)
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

            ParentViewModel = parent;
        }

        #endregion

        #region Private fields

        private readonly IWorkplace workplace;
        private readonly ObservableCollection<TeamViewModel> teamVMs;

        private bool isCurrent;

        #endregion

        #region Properties

        public ReadOnlyObservableCollection<TeamViewModel> TeamVMs { get; }

        public bool IsRemote
        {
            get => workplace.IsRemote;
            set => SetProperty(() => workplace.IsRemote == value, () => workplace.IsRemote = value);
        }

        public bool IsCurrent
        {
            get => isCurrent;
            set => SetProperty(() => isCurrent == value, () => isCurrent = value);
        }

        public int Iterations
        {
            get => workplace.Iterations;
            set => SetProperty(() => workplace.Iterations == value, () => workplace.Iterations = value);
        }

        public int MaximumIterations => workplace.MaximumIterations;
        public int MinimumIterations => workplace.MinimumIterations;

        #endregion

        #region Methods

        protected void Add()
        {
            workplace.AddTeam();
        }

        protected void Copy(int index)
        {
            workplace.CopyTeam(index);
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
            teamVMs.Insert(e.Value.Item1, teamVM);
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

        private ICommand copyTeam;

        public ICommand CopyTeam => RelayCommand.Create(ref copyTeam, o =>
        {
            if (o is TeamViewModel t)
            {
                int index = teamVMs.IndexOf(t);
                if (index == -1)
                    return;
                Copy(index);
            }
        });

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
            else if (o is IList list)
            {
                var teams = list.Cast<TeamViewModel>().ToArray();

                for (int i = 0; i < teams.Length; i++)
                {
                    int index = teamVMs.IndexOf(teams[i]);
                    if (index == -1)
                        continue;

                    Remove(index);
                    i--;
                }
            }
        });

        private ICommand clearTeams;

        public ICommand ClearTeams => RelayCommand.Create(ref clearTeams, o => Clear());

        #endregion

    }
}
