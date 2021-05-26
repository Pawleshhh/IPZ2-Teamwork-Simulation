using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using TeamworkSimulation.Utility;

namespace TeamworkSimulation.Model.Simulation
{
    public class SimulationResultInterpreter
    {

        #region Private fields

        private const int FACTORS_COUNT = 8;

        private readonly string[] factors = { "Tiredness", "Work conditions", "Team effectiveness", "Comfort", "Team Study Comfort", "Help", "Self improvement", "Communication" };

        private int simulationCountSum;

        //private readonly Dictionary<string, List<(double[] x, double[] y)>> vectorsDictionary = new Dictionary<string, List<(double[] x, double[] y)>>();

        private SimulationResultCollection summary;

        #endregion

        #region Methods

        public List<ISimulationResult> InterpretResults(List<double[][][]> allSimResults)
        {
            List<ISimulationResult> resultCollections = new List<ISimulationResult>();

            int i = simulationCountSum,
                j = 1;

            var cachedSimResults = new List<Dictionary<string, (double[] x, double[] y)>>();
            foreach(var simResult in allSimResults)
            {
                var singleSimResult = GetSingleSimulationData(simResult);

                var plotResults = GetPlotResults(singleSimResult, $"Simulation {i}.{j++}");

                resultCollections.Add(plotResults);
                cachedSimResults.Add(singleSimResult);
            }

            var summary = GetSummary(cachedSimResults, $"Simulation {i}");

            resultCollections.Add(summary);

            simulationCountSum++;

            return resultCollections;
        }

        public void Clear()
        {
            simulationCountSum = 1;
            summary = null;
        }

        private Dictionary<string, (double[] x, double[] y)> GetSingleSimulationData(double[][][] results)
        {
            var singleSimulationData = new Dictionary<string, (double[] x, double[] y)>();

            for(int i = 0; i < FACTORS_COUNT; i++)
            {
                singleSimulationData.Add(factors[i], (results[i][0], results[i][1]));
            }

            return singleSimulationData;
        }

        //private void HoldVectors(IEnumerable<(double[] x, double[] y)> vectors)
        //{
        //    int i = 0;
        //    foreach(var vector in vectors)
        //    {
        //        if (vectorsDictionary.ContainsKey(factors[i]))
        //        {
        //            vectorsDictionary[factors[i]].Add(vector);
        //        }
        //        else
        //        {
        //            vectorsDictionary.Add(factors[i], new List<(double[] x, double[] y)>() { vector });
        //        }
        //    }
        //}

        private SimulationResultCollection GetPlotResults(Dictionary<string, (double[] x, double[] y)> simulationResultVectors, string name)
        {
            var plots = new List<PlotResult>();

            for(int i = 0; i < FACTORS_COUNT; i++)
            {
                string key = factors[i];
                List<double[]> vectors = new List<double[]>()
                {
                    simulationResultVectors[key].x,
                    simulationResultVectors[key].y
                };

                plots.Add(new PlotResult(vectors, key));
            }

            return new SimulationResultCollection(plots, name);
        }

        private SimulationResultCollection GetSummary(IEnumerable<Dictionary<string, (double[] x, double[] y)>> allSimulationResultVectors, string name)
        {
            StatisticsResultData GetStatisticsResultData(double[] values, string name)
                => new StatisticsResultData(
                    Statistics.Mean(values),
                    Statistics.Median(values),
                    Statistics.StandardDeviation(values),
                    name);

            var mergedVectors = new Dictionary<string, double[]>();
            var summaryPlots = new List<PlotResult>();

            double[] arr_xs = null;
            foreach (var factor in factors)
            {
                List<double> ys = new List<double>();

                List<double[]> arr_ys = new List<double[]>();
                foreach (var simulationResultVectors in allSimulationResultVectors)
                {
                    ys.AddRange(simulationResultVectors[factor].y);

                    if (arr_xs == null)
                        arr_xs = simulationResultVectors[factor].x;

                    arr_ys.Add(simulationResultVectors[factor].y);
                }

                mergedVectors.Add(factor, ys.ToArray());

                summaryPlots.Add(new PlotResult(new List<double[]>() { arr_xs, Statistics.StatisticsCollection(arr_ys, Statistics.Mean)}, factor + " average"));
                summaryPlots.Add(new PlotResult(new List<double[]>() { arr_xs, Statistics.StatisticsCollection(arr_ys, Statistics.Median) }, factor + " median"));
                summaryPlots.Add(new PlotResult(new List<double[]>() { arr_xs, Statistics.StatisticsCollection(arr_ys, Statistics.StandardDeviation) }, factor + " standard deviation"));
            }

            var statisticsData = new List<StatisticsResultData>();

            foreach(var mergedVector in mergedVectors)
            {
                statisticsData.Add(GetStatisticsResultData(mergedVector.Value, mergedVector.Key));
            }

            if (summary != null)
            {
                List<ISimulationResult> simulationResults = new List<ISimulationResult>();
                simulationResults.Add(new StatisticsResult(statisticsData, "Table"));
                foreach (var plot in summaryPlots)
                {
                    simulationResults.Add(plot);
                }
                summary.Add(new SimulationResultCollection(simulationResults, name));
            }
            else
            {
                List<ISimulationResult> simulationResults = new List<ISimulationResult>();
                simulationResults.Add(new StatisticsResult(statisticsData, "Table"));
                simulationResults.AddRange(summaryPlots);
                summary = new SimulationResultCollection(new List<SimulationResultCollection>() { new SimulationResultCollection(simulationResults, name) }, "Simulations summary");
            }

            return summary;
        }

        #endregion

    }
}
