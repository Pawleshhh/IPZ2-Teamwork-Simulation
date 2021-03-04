using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class WorkerViewModel : TeamMemberViewModel
    {
        #region Constructors
        public WorkerViewModel(Worker worker)
            : base(worker)
        {
            this.worker = worker;
        }
        #endregion

        #region Private fields

        private readonly Worker worker;

        #endregion

        #region Properties

        public WorkStation WorkStation
        {
            get => worker.WorkStation;
            set => SetProperty(() => worker.WorkStation == value, () => worker.WorkStation = value);
        }

        #endregion
    }
}
