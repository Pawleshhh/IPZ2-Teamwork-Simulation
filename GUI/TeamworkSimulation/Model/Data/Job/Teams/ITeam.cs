using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeamworkSimulation.Model
{
    public interface ITeam : IModelItem
    {

        #region Properties

        IReadOnlyList<ITeamMember> TeamMembers { get; }

        #endregion

        #region Events

        event EventHandler<DataEventArgs<(int, ITeamMember)>> Added;
        event EventHandler<DataEventArgs<(int, ITeamMember)>> Removed;
        event EventHandler Cleared;

        #endregion

        #region Methods

        void CopyTeamMember(int index);
        void AddTeamMember();
        void AddTeamMember(ITeamMember teamMember);
        void RemoveTeamMember(ITeamMember teamMember);
        void RemoveTeamMemberAt(int index);
        void ClearTeamMembers();

        ITeam Copy();

        #endregion

    }
}
