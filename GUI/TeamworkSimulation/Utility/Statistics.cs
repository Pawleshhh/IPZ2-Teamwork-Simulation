using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkSimulation.Utility
{
    public static class Statistics
    {

        public static double[] StatisticsCollection(List<double[]> values, Func<double[], double> statistic)
        {
            double[] result = new double[values[0].Length];
            for(int i = 0; i < values[0].Length; i++)
            {
                double[] array = new double[values.Count];

                for(int j = 0; j < array.Length; j++)
                {
                    array[j] = values[j][i];
                }

                result[i] = statistic(array);
            }

            return result;
        }

        public static double Mean(double[] values)
        {
            if (CheckArray(values))
                return 0.0;

            return values.Average();
        }

        public static double Median(double[] values)
        {
            if (CheckArray(values))
                return 0.0;

            var sorted = values.OrderBy(n => n).ToArray();

            var halfLength = sorted.Length / 2;

            if (sorted.Length % 2 == 0)
            {
                return (sorted[halfLength - 1] + sorted[halfLength]) / 2.0;
            }
            else
            {
                return sorted[halfLength / 2];
            }
        }

        public static double StandardDeviation(double[] values)
        {
            if (CheckArray(values))
                return 0.0;

            var avg = Mean(values);

            double sum = 0.0;

            foreach(var value in values)
            {
                sum += Math.Pow(value - avg, 2);
            }

            return Math.Sqrt(sum / values.Length);
        }

        private static bool CheckArray(double[] array)
            => array == null || array.Length == 0;

    }
}
