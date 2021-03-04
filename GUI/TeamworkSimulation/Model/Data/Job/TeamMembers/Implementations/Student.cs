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
    public class Student : TeamMember
    {
        #region Constructors

        public Student()
        {
            SimulationModel = new StudentSimulationModel(this);
        }

        #endregion
        #region Properties
        [DataMember]
        public StudentExperience StudentExperience { get; set; } = new StudentExperience();

        [DataMember]
        public bool IsFullTimeStudy { get; set; }

        #endregion Properties

        #region Methods

        public override ITeamMember Copy()
        {
            return new Student
            {
                Gender = this.Gender,
                Personality = this.Personality,
                StudentExperience = (StudentExperience)this.StudentExperience.Copy()
            };
        }

        protected override IExperience GetExperience()
            => StudentExperience;

        #endregion
    }
}
