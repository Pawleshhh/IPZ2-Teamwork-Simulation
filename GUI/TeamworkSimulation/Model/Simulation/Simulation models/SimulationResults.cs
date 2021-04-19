using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public class SimulationResults
    {

        public SimulationResults(List<double[]> input1, List<double[]> input2, List<double[]> input3, List<double[]> input4, List<double[]> input5, List<double[]> input6, List<double[]> input7, List<double[]> input8, List<double[]> input9)
        {
            Data1 = input1;
            Data2 = input2;
            Data3 = input3;
            Data4 = input4;
            Data5 = input5;
            Data6 = input6;
            Data7 = input7;
            Data8 = input8;
            Data9 = input9;
        }

        public List<double[]> Data1 { get; }
        public List<double[]> Data2 { get; }
        public List<double[]> Data3 { get; }
        public List<double[]> Data4 { get; }
        public List<double[]> Data5 { get; }
        public List<double[]> Data6 { get; }
        public List<double[]> Data7 { get; }
        public List<double[]> Data8 { get; }
        public List<double[]> Data9 { get; }

    }
}
