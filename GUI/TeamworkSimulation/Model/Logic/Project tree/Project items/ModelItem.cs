using System;
using System.Collections.Generic;
using System.Linq;
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

        [DataMember]
        private bool useModel = true;

        public bool UseModel
        {
            get => useModel;
            set
            {
                useModel = value;
                SetChildrenUseModel();

                UseModelChanged?.Invoke(this, EventArgs.Empty);
                InvokeItemChangedEvent();
            }
        }

        public ISimulationModel SimulationModel => simulationModel ??= GetSimulationModel();

        public event EventHandler UseModelChanged;

        protected virtual ISimulationModel GetSimulationModel()
        {
            return SimulationModel<ModelItem>.GetEmptySimulationModel(this);
        }

        private void SetChildrenUseModel()
        {
            foreach(var item in GetProjectItems().Where(n => n is ModelItem).Select(n => (ModelItem)n))
            {
                item.UseModel = UseModel;
            }
        }

    }
}
