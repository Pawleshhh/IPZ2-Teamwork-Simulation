using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamworkSimulation.Model
{
    [DataContract]
    public class WorkerExperience : IExperience
    {

        private WorkBranch workBranch;
        private int age = 20;
        private int companyYears;
        private int branchYears;

        [DataMember]
        public WorkBranch WorkBranch
        {
            get => workBranch;
            set
            {
                workBranch = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        [DataMember]
        public int Age
        {
            get => age;
            set
            {
                age = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        [DataMember]
        public int CompanyYears
        {
            get => companyYears;
            set
            {
                companyYears = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        [DataMember]
        public int BranchYears
        {
            get => branchYears;
            set
            {
                branchYears = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler Changed;

        public virtual IExperience Copy()
        {
            return new WorkerExperience
            {
                WorkBranch = this.WorkBranch,
                Age = this.Age,
                CompanyYears = this.CompanyYears,
                BranchYears = this.BranchYears
            };
        }

    }
}
