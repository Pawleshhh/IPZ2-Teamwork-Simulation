using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TeamworkSimulation.Model;
using TeamworkSimulation.View;
using TeamworkSimulation.ViewModel;

namespace TeamworkSimulation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private Project project;
        private TeamworkSimulationManager manager;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();

            //var deSer = new DataContractSerializer(typeof(Project));
            //using (XmlReader r = XmlReader.Create(".\\project.xml", new XmlReaderSettings()
            //{
            //    IgnoreWhitespace = true
            //}))
            //{
            //    project = (Project)deSer.ReadObject(r);
            //}

            //var projectVM = new ProjectViewModel(project);
            //project.AddWorkplace();
            //window.DataContext = projectVM;
            manager = new TeamworkSimulationManager(new WindowsServicesFactory());
            window.DataContext = new MainViewModel(manager);

            MainWindow = window;
            window.Closing += Window_Closing;

            window.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !manager.WhenClosing();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

            //var ser = new DataContractSerializer(typeof(Project));
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //using (XmlWriter writer = XmlWriter.Create(".\\project.xml", settings))
            //{
            //    ser.WriteObject(writer, project);
            //}
        }
    }
}
