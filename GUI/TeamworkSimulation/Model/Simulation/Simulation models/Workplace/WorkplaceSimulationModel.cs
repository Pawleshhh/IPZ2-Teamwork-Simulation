using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public abstract class WorkplaceSimulationModel<T> : SimulationModel<T>
        where T : IWorkplace
    {

        #region Constructors

        protected WorkplaceSimulationModel(T model) : base(model)
        {
        }

        #endregion

        #region Methods

        protected virtual int GetWorkplaceMode()
            => model.IsRemote ? 1 : 0;

        protected abstract int GetWorkplaceType();


        #endregion

    }
}
