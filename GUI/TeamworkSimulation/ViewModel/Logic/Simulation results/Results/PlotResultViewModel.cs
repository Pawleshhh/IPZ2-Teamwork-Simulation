using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class PlotResultViewModel : SimulationResultViewModel
    {
        #region Constructors
        public PlotResultViewModel(PlotResult plotResult, IViewModel parent)
            : base(plotResult, parent)
        {
            this.plotResult = plotResult;

            Plot = new PlotModel { Title = plotResult.Name };
            generatePlot(Plot, plotResult.Result, Name, "x", "y", PlotType.linear);
        }
        #endregion

        #region Private fields
        private PlotResult plotResult;
        #endregion

        #region Properties

        public PlotModel Plot { get; private set; }

        #endregion

        #region Methods

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

        private List<DataPoint> convertDataToDataPoints(List<double[]> inputData)
        {
            List<DataPoint> output = new List<DataPoint>();
            try
            {

                var xs = inputData[0]; //tablica z x
                var ys = inputData[1]; //tablica z y

                if (xs.Length != ys.Length)
                    throw new InvalidOperationException();

                for (int i = 0; i < xs.Length; i++)
                {
                    output.Add(new DataPoint(xs[i], ys[i]));
                }

            }
            catch (Exception e)
            {
                throw new Exception("Data wasn't converted correctly, verify type of inputData: " + e.Message);
            }
            return output;
        }


        private Series generateSeries(List<double[]> inputData, PlotType targetType)
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

        private void ResetPlot()
        {
            Plot.ResetAllAxes();
            OnPropertyChanged(nameof(Plot));
        }
        #endregion

        #region Commands

        private ICommand resetPlotModel;

        public ICommand ResetPlotModel => RelayCommand.Create(ref resetPlotModel, o =>
        {
            ResetPlot();
        });

        #endregion

    }

    public enum PlotType
    {
        linear, histogram
    }
}
