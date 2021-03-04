using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using TeamworkSimulation.Model.Simulation;
using TeamworkSimulation.Utility;

namespace TeamworkSimulation.Model
{
    [DataContract]
    public class Worker : TeamMember
    {
        #region Constructors

        public Worker()
        {
            SimulationModel = new WorkerSimulationModel(this);
        }

        #endregion

        #region Private fields

        private WorkStation workStation;

        #endregion

        #region Properties

        [DataMember]
        public WorkStation WorkStation
        {
            get => workStation;
            set
            {
                if (SetProperty(() => workStation == value, () => workStation = value))
                    InvokeItemChangedEvent();
            }
        }
        [DataMember]
        public WorkerExperience WorkerExperience { get; set; } = new WorkerExperience();

        #endregion Properties

        #region Methods

        public override ITeamMember Copy()
        {
            return new Worker
            {
                Gender = this.Gender,
                Personality = this.Personality,
                WorkStation = this.WorkStation,
                WorkerExperience = (WorkerExperience)this.WorkerExperience.Copy()
            };
        }

        protected override IExperience GetExperience()
            => WorkerExperience;

        #endregion

    }
}