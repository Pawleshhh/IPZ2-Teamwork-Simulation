using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    //public class SimulationResultsViewModel : NotifyPropertyChanges, IViewModel
    //{

    //    #region Constructors
    //    public SimulationResultsViewModel(SimulationResultCollection simulationResults, IViewModel parent)
    //    {
    //        this.simulationResults = simulationResults;
    //        ParentViewModel = parent;

    //        var model1 = new PlotModel { Title = "Tierd_Factor" };
    //        var model2 = new PlotModel { Title = "WorkConditions_Factor" };
    //        var model3 = new PlotModel { Title = "TeamEffictiveness_Factor" };
    //        var model4 = new PlotModel { Title = "Comfort_Factor" };
    //        var model5 = new PlotModel { Title = "Team_Study_Comfort_Factor" };
    //        var model6 = new PlotModel { Title = "Help_Factor" };
    //        var model7 = new PlotModel { Title = "SelfImprovement_Factor" };
    //        var model8 = new PlotModel { Title = "TeamCom_Factor" };

    //        generatePlot(model1, simulationResults.Data1, "test", "test", "test", PlotType.linear);
    //        generatePlot(model2, simulationResults.Data2, "test", "test", "test", PlotType.linear);
    //        generatePlot(model3, simulationResults.Data3, "test", "test", "test", PlotType.linear);
    //        generatePlot(model4, simulationResults.Data4, "test", "test", "test", PlotType.linear);
    //        generatePlot(model5, simulationResults.Data5, "test", "test", "test", PlotType.linear);
    //        generatePlot(model6, simulationResults.Data6, "test", "test", "test", PlotType.linear);
    //        generatePlot(model7, simulationResults.Data7, "test", "test", "test", PlotType.linear);
    //        generatePlot(model8, simulationResults.Data8, "test", "test", "test", PlotType.linear);
    //        //generatePlot(model9, simulationResults.Data9, "test", "test", "test", PlotType.linear);


    //        plotModels = new ObservableCollection<PlotModel>() { model1, model2, model3,
    //                                                             model4, model5, model6,
    //                                                             model7, model8 };
    //        PlotModels = new ReadOnlyObservableCollection<PlotModel>(plotModels);

    //        CurrentPlot = PlotModels[0];
    //    }
    //    #endregion

    //    #region Private fields

    //    private readonly SimulationResultCollection simulationResults;

    //    private readonly ObservableCollection<PlotModel> plotModels;

    //    #endregion

    //    #region Properties

    //    public IViewModel ParentViewModel { get; set; }

    //    public ReadOnlyObservableCollection<PlotModel> PlotModels { get; }

    //    public PlotModel CurrentPlot { get; private set; }

    //    //public PlotModel model1 { get; set; }
    //    //public PlotModel model2 { get; set; }
    //    //public PlotModel model3 { get; set; }
    //    //public PlotModel model4 { get; set; }
    //    //public PlotModel model5 { get; set; }
    //    //public PlotModel model6 { get; set; }
    //    //public PlotModel model7 { get; set; }
    //    //public PlotModel model8 { get; set; }
    //    //public PlotModel model9 { get; set; }

    //    #endregion

    //    #region Methods

    //    /// <summary>
    //    /// Method generates ready plot for set of data.
    //    /// </summary>
    //    /// <param name="inputData">Pass data which will be displayed on plot</param>
    //    /// <param name="title">Title of the plot</param>
    //    /// <param name="xTitle">Title of x Label (pass what data is on X axis)</param>
    //    /// <param name="yTitle">Title of y Label (pass what data is on Y axis)</param>
    //    /// <param name="targetType">Choose type of plot (histogram or linear)</param>
    //    public void generatePlot(PlotModel model, List<double[]> inputData, string title, string xTitle, string yTitle, PlotType targetType)
    //    {
    //        model.Series.Clear();

    //        var series = generateSeries(inputData, targetType);
    //        model.Series.Add(series);
    //        model.Axes.Add(new OxyPlot.Axes.LinearAxis()
    //        {
    //            Position = OxyPlot.Axes.AxisPosition.Bottom,
    //            Title = xTitle
    //        });
    //        model.Axes.Add(new OxyPlot.Axes.LinearAxis()
    //        {
    //            Position = OxyPlot.Axes.AxisPosition.Left,
    //            Title = yTitle
    //        });
    //        model.InvalidatePlot(true);
    //    }
    //    /// <summary>
    //    /// Help method for converting input data to DataPoint type.
    //    /// </summary>
    //    /// <param name="inputData">Set of data which should be converted to List of DataPoints</param>
    //    /// <returns>List of DataPoints</returns>
    //    private List<DataPoint> convertDataToDataPoints(List<double[]> inputData)
    //    {
    //        List<DataPoint> output = new List<DataPoint>();
    //        try
    //        {

    //            var xs = inputData[0]; //tablica z x
    //            var ys = inputData[1]; //tablica z y

    //            if (xs.Length != ys.Length)
    //                throw new InvalidOperationException();

    //            for(int i = 0; i < xs.Length; i++)
    //            {
    //                output.Add(new DataPoint(xs[i], ys[i]));
    //            }


    //            //foreach (double[] i in inputData)
    //            //{

    //            //    output.Add(new DataPoint(i[0], i[1]));

    //            //}
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception("Data wasn't converted correctly, verify type of inputData: " + e.Message);
    //        }
    //        return output;
    //    }
    //    /// <summary>
    //    /// Generate Series for plot
    //    /// </summary>
    //    /// <param name="inputData">Data to serialize</param>
    //    /// <param name="targetType">Select type of target plot (Histogram or Linear)</param>
    //    /// <returns>Returns Series for required plot</returns>

    //    private Series generateSeries(List<double[]> inputData, PlotType targetType)
    //    {
    //        List<DataPoint> data = convertDataToDataPoints(inputData);
    //        if (targetType == PlotType.histogram)
    //        {
    //            var temp = new StemSeries();
    //            foreach (DataPoint i in data)
    //            {
    //                temp.Points.Add(i);
    //            }
    //            return temp;
    //        }
    //        if (targetType == PlotType.linear)
    //        {
    //            var series = new FunctionSeries();
    //            foreach (DataPoint i in data)
    //            {
    //                series.Points.Add(i);
    //            }
    //            return series;
    //        }
    //        return null;
    //    }

    //    private void SelectPlotModel(PlotModel plt)
    //    {
    //        CurrentPlot = plt;
    //        OnPropertyChanged(nameof(CurrentPlot));
    //    }
    //    #endregion

    //    #region Commands

    //    private ICommand selectPlot;

    //    public ICommand SelectPlot => RelayCommand.Create(ref selectPlot, o =>
    //    {
    //        if(o is PlotModel plt)
    //        {
    //            SelectPlotModel(plt);
    //        }
    //    });

    //    #endregion

    //}

    //public enum PlotType
    //{
    //    linear, histogram
    //}
}
