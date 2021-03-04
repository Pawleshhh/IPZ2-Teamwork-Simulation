using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    [DataContract]
    public abstract class ModelItem : ProjectItem
    {

        protected ModelItem()
        {
            SimulationModel = SimulationModel<ModelItem>.GetEmptySimulationModel(this);
        }

        public ISimulationModel SimulationModel { get; protected set; }

    }
}
