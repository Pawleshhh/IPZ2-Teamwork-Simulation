using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public abstract class ExperienceViewModel : NotifyPropertyChanges
    {

        #region Constructors

        protected ExperienceViewModel(IExperience experience)
        {
            this.experience = experience;
        }

        #endregion

        #region Private fields

        private readonly IExperience experience;

        #endregion

        #region Properties

        public int Age
        {
            get => experience.Age;
            set => SetProperty(() => experience.Age == value, () => experience.Age = value);
        }

        #endregion

    }
}
