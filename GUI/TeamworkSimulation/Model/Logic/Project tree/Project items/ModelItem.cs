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
        }

        private ISimulationModel simulationModel;

        public ISimulationModel SimulationModel
        {
            get => simulationModel ??= GetSimulationModel();
        }

        protected virtual ISimulationModel GetSimulationModel()
        {
            return SimulationModel<ModelItem>.GetEmptySimulationModel(this);
        }

    }
}
