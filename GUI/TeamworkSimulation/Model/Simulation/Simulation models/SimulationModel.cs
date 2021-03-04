using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class SimulationModel<T> : ISimulationModel
    {

        protected SimulationModel(T model)
        {
            this.model = model ??
                throw new ArgumentNullException(nameof(model));
        }

        protected readonly T model;

        public virtual int[] GetAttributes()
            => new int[0];

        public static ISimulationModel GetEmptySimulationModel(T model)
            => new SimulationModel<T>(model);

    }
}
