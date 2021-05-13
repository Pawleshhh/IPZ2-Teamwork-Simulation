using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class CompanySimulationModel : WorkplaceSimulationModel<Company>
    {

        public CompanySimulationModel(Company company)
            : base(company)
        {

        }

        public override int[] GetAttributes()
        {
            return new int[]
            {
                GetWorkplaceType(),
                GetWorkplaceMode(),
            };
        }

        protected override int GetWorkplaceType()
            => 1;
    }
}
