using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using TeamworkSimulation.Model.Simulation;
using TeamworkSimulation.Utility;

namespace TeamworkSimulation.Model
{
    [DataContract]
    [KnownType(typeof(Worker))]
    [KnownType(typeof(Student))]
    public abstract class TeamMember : ModelItem, ITeamMember
    {

        #region Constructors

        public TeamMember()
        {
            GetExperience().Changed += TeamMember_Changed;
            ItemName = "Team member";
        }

        #endregion

        #region Private fields

        private Genders gender;
        private Personality personality;

        #endregion

        #region Properties

        [DataMember]
        public Genders Gender
        {
            get => gender;
            set
            {
                if (SetProperty(() => gender == value, () => gender = value))
                    InvokeItemChangedEvent();
            }
        }
        [DataMember]
        public Personality Personality
        {
            get => personality;
            set
            {
                if (SetProperty(() => personality == value, () => personality = value))
                    InvokeItemChangedEvent();
            }
        }
        IExperience ITeamMember.Experience => GetExperience();

        #endregion

        #region Methods

        public abstract ITeamMember Copy();

        protected abstract IExperience GetExperience();

        private void TeamMember_Changed(object sender, EventArgs e)
        {
            InvokeItemChangedEvent();
        }

        #endregion


        #region ProjectItem

        protected override void AddProjectItem(IProjectItem projectItem)
        {

        }
        protected override void RemoveProjectItem(IProjectItem projectItem)
        {

        }
        protected override void ClearProjectItems()
        {

        }

        protected override bool CanContainProjectItem(IProjectItem projectItem)
        {
            return false;
        }

        protected override IReadOnlyCollection<IProjectItem> GetProjectItems()
        {
            return new IProjectItem[0];
        }

        #endregion
    }
}
