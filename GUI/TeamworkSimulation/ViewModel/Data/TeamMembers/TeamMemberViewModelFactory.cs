using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public static class TeamMemberViewModelFactory
    {

        public static TeamMemberViewModel Create(ITeamMember teamMember)
        {
            switch(teamMember)
            {
                case Worker w:
                    return new WorkerViewModel(w);
                case Student s:
                    return new StudentViewModel(s);
                default:
                    throw new InvalidCastException($"Not recognized type of team member: {teamMember.GetType()}");
            }
        }

    }
}
