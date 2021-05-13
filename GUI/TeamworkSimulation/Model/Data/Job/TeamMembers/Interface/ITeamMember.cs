using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    public interface ITeamMember : IModelItem
    {

        Genders Gender { get; set; }
        Personality Personality { get; set; }
        IExperience Experience { get; }

        ITeamMember Copy();

    }
}
