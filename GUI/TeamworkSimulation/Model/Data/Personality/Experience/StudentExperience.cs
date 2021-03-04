using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamworkSimulation.Model
{
    [DataContract]
    public class StudentExperience : IExperience
    {

        private FieldOfStudy fieldOfStudy;
        private CollegeDegree degree;
        private int age = 20;
        private int collegeYears = 1;

        [DataMember]
        public FieldOfStudy FieldOfStudy
        {
            get => fieldOfStudy;
            set
            {
                fieldOfStudy = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        [DataMember]
        public CollegeDegree Degree
        {
            get => degree;
            set
            {
                degree = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        [DataMember]
        public int Age
        {
            get => age;
            set
            {
                age = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
        [DataMember]
        public int CollegeYears
        {
            get => collegeYears;
            set
            {
                collegeYears = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler Changed;

        public virtual IExperience Copy()
        {
            return new StudentExperience
            {
                Degree = this.Degree,
                Age = this.Age,
                CollegeYears = this.CollegeYears
            };
        }

    }
}
