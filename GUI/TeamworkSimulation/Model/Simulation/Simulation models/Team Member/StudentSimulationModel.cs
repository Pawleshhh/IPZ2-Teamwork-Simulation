using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class StudentSimulationModel : TeamMemberSimulationModel<Student>
    {
        public StudentSimulationModel(Student student)
            :base(student)
        {

        }


        public override int[] GetAttributes()
        {
            return new int[]
            {
                GetGender(),
                (int)model.StudentExperience.FieldOfStudy + 1,
                GetCollegeYears(),
                (int)model.StudentExperience.Degree + 1,
                GetFullTimeStudies(),
                (int)model.Personality + 1,
            };
        }

        protected override int GetAge()
        {
            throw new NotImplementedException();
        }

        protected virtual int GetCollegeYears()
        {
            int cyears = model.StudentExperience.CollegeYears;
            if (cyears <= 0 || cyears > 8)
                throw new InvalidOperationException();

            return cyears;
        }

        protected virtual int GetFullTimeStudies()
            => model.IsFullTimeStudy ? 1 : 2;

    }
}
