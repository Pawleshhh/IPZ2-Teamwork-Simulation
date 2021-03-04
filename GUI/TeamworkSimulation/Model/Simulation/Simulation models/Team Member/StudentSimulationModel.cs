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
            return -1;
            //int age = model.StudentExperience.Age;

            //if (age < 20)
            //    throw new InvalidOperationException();
            //else if (age >= 20 && age < 30)
            //    return 1;
            //else if (age >= 30 && age < 40)
            //    return 2;
            //else if (age >= 40 && age < 50)
            //    return 3;
            //else
            //    return 4;
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
