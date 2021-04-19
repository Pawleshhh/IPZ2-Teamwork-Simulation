using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeamworkSimulation.View.Windows
{
    /// <summary>
    /// Interaction logic for SimulationResultsWindow.xaml
    /// </summary>
    public partial class SimulationResultsWindow : Window
    {
        public enum PlotType
        {
            linear, histogram
        }
        public PlotModel model1 { get; set; }
        public PlotModel model2 { get; set; }
        public PlotModel model3 { get; set; }
        public PlotModel model4 { get; set; }
        public PlotModel model5 { get; set; }
        public PlotModel model6 { get; set; }
        public PlotModel model7 { get; set; }
        public PlotModel model8 { get; set; }
        public PlotModel model9 { get; set; }

        public SimulationResultsWindow(List<double[]> input1, List<double[]> input2, List<double[]> input3, List<double[]> input4, List<double[]> input5, List<double[]> input6, List<double[]> input7, List<double[]> input8, List<double[]> input9)
        {
            InitializeComponent();
            DataContext = this;

            model1 = new PlotModel { Title = "Tierd_Factor" };
            model2 = new PlotModel { Title = "WorkConditions_Factor" };
            model3 = new PlotModel { Title = "TeamEffictiveness_Factor" };
            model4 = new PlotModel { Title = "Comfort_Factor" };
            model5 = new PlotModel { Title = "Team_Study_Comfort_Factor" };
            model6 = new PlotModel { Title = "Help_Factor" };
            model7 = new PlotModel { Title = "SelfImprovement_Factor" };
            model8 = new PlotModel { Title = " " };
            model9 = new PlotModel { Title = "TeamCom_Factor" };

            generatePlot(model1, input1, "test", "test", "test", PlotType.linear);
            generatePlot(model2, input2, "test", "test", "test", PlotType.linear);
            generatePlot(model3, input3, "test", "test", "test", PlotType.linear);
            generatePlot(model4, input4, "test", "test", "test", PlotType.linear);
            generatePlot(model5, input5, "test", "test", "test", PlotType.linear);
            generatePlot(model6, input6, "test", "test", "test", PlotType.linear);
            generatePlot(model7, input7, "test", "test", "test", PlotType.linear);
            generatePlot(model8, input8, "test", "test", "test", PlotType.linear);
            generatePlot(model9, input9, "test", "test", "test", PlotType.linear);
        }

        /// <summary>
        /// Method generates ready plot for set of data.
        /// </summary>
        /// <param name="inputData">Pass data which will be displayed on plot</param>
        /// <param name="title">Title of the plot</param>
        /// <param name="xTitle">Title of x Label (pass what data is on X axis)</param>
        /// <param name="yTitle">Title of y Label (pass what data is on Y axis)</param>
        /// <param name="targetType">Choose type of plot (histogram or linear)</param>
        public void generatePlot(PlotModel model, List<double[]> inputData, string title, string xTitle, string yTitle, PlotType targetType)
        {
            model.Series.Clear();

            var series = generateSeries(inputData, targetType);
            model.Series.Add(series);
            model.Axes.Add(new OxyPlot.Axes.LinearAxis()
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = xTitle
            });
            model.Axes.Add(new OxyPlot.Axes.LinearAxis()
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = yTitle
            });
            model.InvalidatePlot(true);
        }
        /// <summary>
        /// Help method for converting input data to DataPoint type.
        /// </summary>
        /// <param name="inputData">Set of data which should be converted to List of DataPoints</param>
        /// <returns>List of DataPoints</returns>
        private static List<DataPoint> convertDataToDataPoints(List<double[]> inputData)
        {
            List<DataPoint> output = new List<DataPoint>();
            try
            {
                foreach (double[] i in inputData)
                {

                    output.Add(new DataPoint(i[0], i[1]));

                }
            }
            catch (Exception e)
            {
                throw new Exception("Data wasn't converted correctly, werify type of inputData: " + e.Message);
            }
            return output;
        }
        /// <summary>
        /// Generate Series for plot
        /// </summary>
        /// <param name="inputData">Data to serialize</param>
        /// <param name="targetType">Select type of target plot (Histogram or Linear)</param>
        /// <returns>Returns Series for required plot</returns>

        private static Series generateSeries(List<double[]> inputData, PlotType targetType)
        {
            List<DataPoint> data = convertDataToDataPoints(inputData);
            if (targetType == PlotType.histogram)
            {
                var temp = new StemSeries();
                foreach (DataPoint i in data)
                {
                    temp.Points.Add(i);
                }
                return temp;
            }
            if (targetType == PlotType.linear)
            {
                var series = new FunctionSeries();
                foreach (DataPoint i in data)
                {
                    series.Points.Add(i);
                }
                return series;
            }
            return null;
        }
    }
}
