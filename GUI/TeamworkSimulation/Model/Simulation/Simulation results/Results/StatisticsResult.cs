using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model.Simulation
{
    public class StatisticsResult : SimulationResult<IList<StatisticsResultData>>
    {

        public StatisticsResult(IList<StatisticsResultData> result, string name) : base(result)
        {
            this.name = name;
        }

        private string name;

        public override string Name => name;
    }

    public class StatisticsResultData
    {

        public StatisticsResultData(double avg, double median, double std, string name)
        {
            Mean = avg;
            Median = median;
            Std = std;

            Name = name;
        }

        public string Name { get; }

        public double Mean { get; }
        public double Median { get; }
        public double Std { get; }

    }
}
