using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class StudentExperienceViewModel : ExperienceViewModel
    {

        #region Constructors
        public StudentExperienceViewModel(StudentExperience experience) : base(experience)
        {
            studentExperience = experience;
        }
        #endregion

        #region Private fields

        private readonly StudentExperience studentExperience;

        #endregion

        #region Properties

        public FieldOfStudy FieldOfStudy
        {
            get => studentExperience.FieldOfStudy;
            set => SetProperty(() => studentExperience.FieldOfStudy == value, () => studentExperience.FieldOfStudy = value);
        }

        public CollegeDegree Degree
        {
            get => studentExperience.Degree;
            set => SetProperty(() => studentExperience.Degree == value, () => studentExperience.Degree = value);
        }

        public int CollegeYears
        {
            get => studentExperience.CollegeYears;
            set => SetProperty(() => studentExperience.CollegeYears == value, () => studentExperience.CollegeYears = value);
        }

        #endregion

    }
}
