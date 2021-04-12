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
    public class TeamViewModel : ProjectItemViewModel
    {

        #region Constructors

        public TeamViewModel(ITeam team)
            :base(team)
        {
            this.team = team ?? throw new ArgumentNullException(nameof(team));
            teamMemberVMs = new ObservableCollection<TeamMemberViewModel>(
                team.TeamMembers.Select(n => TeamMemberViewModelFactory.Create(n)));

            TeamMembers = new ReadOnlyObservableCollection<TeamMemberViewModel>(teamMemberVMs);

            team.Added += Team_Added;
            team.Removed += Team_Removed;
            team.Cleared += Team_Cleared;

            foreach (var v in teamMemberVMs)
                AddProjectItem(v);
        }

        #endregion

        #region Private fields

        private readonly ITeam team;
        private ObservableCollection<TeamMemberViewModel> teamMemberVMs;

        #endregion

        #region Properties

        public ReadOnlyObservableCollection<TeamMemberViewModel> TeamMembers { get; private set; }

        public TeamMemberType TeamMemberType { get; set; }

        #endregion

        #region Methods

        protected void Add()
        {
            team.AddTeamMember();
        }

        protected void Copy(int index)
        {
            team.CopyTeamMember(index);
        }

        protected void Remove(int index)
        {
            team.RemoveTeamMemberAt(index);
        }

        protected void Clear()
        {
            team.ClearProjectItems();
        }

        private void Team_Added(object sender, DataEventArgs<(int, ITeamMember)> e)
        {
            TeamMemberViewModel teamMemberVM = TeamMemberViewModelFactory.Create(e.Value.Item2);
            teamMemberVM.ParentViewModel = this;
            teamMemberVMs.Insert(e.Value.Item1, teamMemberVM);
            AddProjectItem(teamMemberVM);
        }

        private void Team_Removed(object sender, DataEventArgs<(int, ITeamMember)> e)
        {
            teamMemberVMs.RemoveAt(e.Value.Item1);
            RemoveProjectItem(e.Value.Item1);
        }

        private void Team_Cleared(object sender, EventArgs e)
        {
            teamMemberVMs.Clear();
            ClearProjectItems();
        }

        #endregion

        #region Commands

        private ICommand addTeamMember;

        public ICommand AddTeamMember => RelayCommand.Create(ref addTeamMember, o => Add());

        private ICommand copyTeamMember;

        public ICommand CopyTeamMember => RelayCommand.Create(ref copyTeamMember, o =>
        {
            if (o is TeamMemberViewModel tm)
            {
                int index = teamMemberVMs.IndexOf(tm);
                if (index == -1)
                    return;

                Copy(index);
            }
        });

        private ICommand removeTeamMember;

        public ICommand RemoveTeamMember => RelayCommand.Create(ref removeTeamMember, o =>
        {
            if (o is TeamMemberViewModel tm)
            {
                int index = teamMemberVMs.IndexOf(tm);
                if (index == -1)
                    return;

                Remove(index);
            }
            else if (o is IList list)
            {
                var teamMembers = list.Cast<TeamMemberViewModel>().ToArray();

                for(int i = 0; i < teamMembers.Length; i++)
                {
                    int index = teamMemberVMs.IndexOf(teamMembers[i]);
                    if (index == -1)
                        continue;

                    Remove(index);
                    i--;
                }
            }
        });

        private ICommand clearTeamMembers;

        public ICommand ClearTeamMembers => RelayCommand.Create(ref clearTeamMembers, o => Clear());

        #endregion
    }
}
