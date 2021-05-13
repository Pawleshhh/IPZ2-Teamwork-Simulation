using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public interface IWorkplace : IModelItem
    {

        #region Properties

        IReadOnlyList<ITeam> Teams { get; }

        int TotalTeamMemberCount { get; }

        IErgonomy Ergonomy { get; set; }
        ITechnology Technology { get; set; }

        bool IsRemote { get; set; }

        #endregion

        #region Events

        event EventHandler<DataEventArgs<(int, ITeam)>> Added;
        event EventHandler<DataEventArgs<(int, ITeam)>> Removed;
        event EventHandler Cleared;

        #endregion

        #region Methods

        void AddTeam();
        void CopyTeam(int index);
        void AddTeam(ITeam team);
        void RemoveTeam(ITeam team);
        void RemoveTeamAt(int index);
        void ClearTeams();

        #endregion

    }
}
