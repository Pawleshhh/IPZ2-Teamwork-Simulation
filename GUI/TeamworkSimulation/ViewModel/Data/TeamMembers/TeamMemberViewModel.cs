using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public abstract class TeamMemberViewModel : ModelItemViewModel
    {

        #region Constructors

        protected TeamMemberViewModel(ITeamMember teamMember)
            :base(teamMember)
        {
            this.teamMember = teamMember ?? throw new ArgumentNullException(nameof(teamMember));
            ExperienceVM = ExperienceViewModelFactory.Create(teamMember.Experience);
        }

        #endregion

        #region Private fields

        private readonly ITeamMember teamMember;

        #endregion

        #region Properties

        public Genders Gender
        {
            get => teamMember.Gender;
            set => SetProperty(() => teamMember.Gender == value, () => teamMember.Gender = value);
        }

        public Personality Personality
        {
            get => teamMember.Personality;
            set => SetProperty(() => teamMember.Personality == value, () => teamMember.Personality = value);
        }

        public ExperienceViewModel ExperienceVM { get; private set; }

        #endregion

        #region Methods

        #endregion

        #region Commands

        #endregion
    }
}
