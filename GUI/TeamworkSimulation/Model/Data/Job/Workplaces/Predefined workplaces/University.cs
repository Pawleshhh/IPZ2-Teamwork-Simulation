using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    public class University : Workplace<Team<Student>>
    {
        public University()
        {
            ItemName = "University";
        }

        protected override ISimulationModel GetSimulationModel()
        {
            return new UniversitySimulationModel(this);
        }

    }
}
