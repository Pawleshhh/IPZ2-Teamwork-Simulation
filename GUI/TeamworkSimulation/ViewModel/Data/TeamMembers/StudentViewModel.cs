using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class StudentViewModel : TeamMemberViewModel
    {
        #region Constructors
        public StudentViewModel(Student student)
            :base(student)
        {
            this.student = student;
        }
        #endregion

        #region Private fields

        private readonly Student student;

        #endregion

        #region Properties

        public bool IsFullTimeStudy
        {
            get => student.IsFullTimeStudy;
            set => SetProperty(() => student.IsFullTimeStudy == value, () => student.IsFullTimeStudy = value);
        }

        #endregion

    }
}
