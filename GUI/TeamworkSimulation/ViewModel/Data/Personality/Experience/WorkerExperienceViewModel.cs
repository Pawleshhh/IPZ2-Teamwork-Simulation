using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class WorkerExperienceViewModel : ExperienceViewModel
    {
        #region Constructors
        public WorkerExperienceViewModel(WorkerExperience experience) : base(experience)
        {
            workerExperience = experience;
        }
        #endregion

        #region Private fields

        private readonly WorkerExperience workerExperience;

        #endregion

        #region Properties

        public WorkBranch WorkBranch
        {
            get => workerExperience.WorkBranch;
            set => SetProperty(() => workerExperience.WorkBranch == value, () => workerExperience.WorkBranch = value);
        }

        public int CompanyYears
        {
            get => workerExperience.CompanyYears;
            set => SetProperty(() => workerExperience.CompanyYears == value, () => workerExperience.CompanyYears = value);
        }

        public int BranchYears
        {
            get => workerExperience.BranchYears;
            set => SetProperty(() => workerExperience.BranchYears == value, () => workerExperience.BranchYears = value);
        }

        #endregion
    }
}
