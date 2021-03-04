using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class WorkerSimulationModel : TeamMemberSimulationModel<Worker>
    {

        public WorkerSimulationModel(Worker worker)
            :base(worker)
        {

        }

        public override int[] GetAttributes()
        {
            return new int[]
            {
                GetGender(),
                GetAge(),
                (int)model.WorkerExperience.WorkBranch + 1,
                (int)model.WorkStation + 1,
                GetCompanyYears(),
                GetBranchYears(),
                (int)model.Personality + 1
            };
        }

        protected override int GetAge()
        {
            int age = model.WorkerExperience.Age;

            if (age < 20)
                throw new InvalidOperationException();
            else if (age >= 20 && age < 30)
                return 1;
            else if (age >= 30 && age < 40)
                return 2;
            else if (age >= 40 && age < 50)
                return 3;
            else
                return 4;
        }

        protected virtual int GetCompanyYears()
        {
            int cyears = model.WorkerExperience.CompanyYears;
            if (cyears < 0)
                throw new InvalidOperationException();
            else if (cyears < 1)
                return 1;
            else if (cyears >= 1 && cyears <= 2)
                return 2;
            else if (cyears > 2 && cyears <= 5)
                return 3;
            else
                return 4;
        }

        protected virtual int GetBranchYears()
        {
            int byears = model.WorkerExperience.BranchYears;
            if (byears < 0)
                throw new InvalidOperationException();
            else if (byears < 1)
                return 1;
            else if (byears >= 1 && byears <= 2)
                return 2;
            else if (byears > 2 && byears <= 5)
                return 3;
            else if (byears >= 6 && byears <= 10)
                return 4;
            else
                return 5;
        }

    }
}
