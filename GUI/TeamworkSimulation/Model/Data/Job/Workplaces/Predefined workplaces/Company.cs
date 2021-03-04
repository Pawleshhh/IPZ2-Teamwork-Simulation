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
            SimulationModel = new CompanySimulationModel(this);
            ItemName = "Company";
        }
    }
}
