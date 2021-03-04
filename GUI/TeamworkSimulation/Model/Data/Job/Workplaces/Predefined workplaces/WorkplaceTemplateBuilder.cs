using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamworkSimulation.Model
{
    [DataContract]
    public class WorkplaceTemplateBuilder
    {

        [DataMember]
        public WorkplaceType WorkplaceType { get; set; }

        public IWorkplace BuildWorkplace()
        {
            switch(WorkplaceType)
            {
                case WorkplaceType.Company:
                    return new Company();
                case WorkplaceType.Univercity:
                    return new University();
                default:
                    throw new InvalidOperationException();
            }
        }

    }

    public enum WorkplaceType
    {
        Company,
        Univercity
    }
}
