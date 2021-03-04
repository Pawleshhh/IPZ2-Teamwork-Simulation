using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public abstract class TeamMemberSimulationModel<T> : SimulationModel<T>
        where T : ITeamMember
    {
        protected TeamMemberSimulationModel(T teamMember)
            :base(teamMember)
        {

        }

        protected abstract int GetAge();
        protected virtual int GetGender()
        {
            return model.Gender == Genders.Male ? 1 : 2;
        }

    }
}
