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
            SimulationModel = new UnivercitySimulationModel(this);
            ItemName = "University";
        }

    }
}
