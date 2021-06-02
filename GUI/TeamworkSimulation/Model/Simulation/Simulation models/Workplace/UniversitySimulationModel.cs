using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class UniversitySimulationModel : WorkplaceSimulationModel<University>
    {

        public UniversitySimulationModel(University university)
            :base(university)
        {

        }

        public override int[] GetAttributes()
        {
            return new int[]
            {
                GetWorkplaceType(),
                GetWorkplaceMode()
            };
        }

        protected override int GetWorkplaceType()
            => 0;
    }
}
