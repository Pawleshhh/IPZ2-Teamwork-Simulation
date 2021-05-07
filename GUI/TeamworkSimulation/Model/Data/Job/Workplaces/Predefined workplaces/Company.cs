using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    public class Company : Workplace<Team<Worker>>
    {
        public Company()
        {
            ItemName = "Company";
        }

        protected override ISimulationModel GetSimulationModel()
        {
            return new CompanySimulationModel(this);
        }
    }
}
