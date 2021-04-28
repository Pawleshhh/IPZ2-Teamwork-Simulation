using System;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class MainViewModel : NotifyPropertyChanges
    {

        #region Constructors

        public MainViewModel(TeamworkSimulationManager manager, IOpenView simulationResultsView)
        {
            this.manager = manager;
            manager.CreateNewProject();
            ProjectVM = new ProjectViewModel(manager.Project);

            manager.SimulationDirector.Started += SimulationDirector_IsWorkingChanged;
            manager.SimulationDirector.Stopped += SimulationDirector_IsWorkingChanged;

            this.simulationResultsView = simulationResultsView;
        }

        #endregion

        #region Private fields

        private readonly TeamworkSimulationManager manager;

        private readonly IOpenView simulationResultsView;

        private SimulationResultsViewModel simulationResultsVM;

        #endregion

        #region Properties

        public ProjectViewModel ProjectVM { get; private set; }

        public bool IsWorking => manager.SimulationDirector.IsWorking;

        #endregion

        #region Methods

        private void SimulationDirector_IsWorkingChanged(object sender, EventArgs e)
        {
            if (!IsWorking)
            {
                simulationResultsVM = new SimulationResultsViewModel(manager.SimulationDirector.SimulationResults, null);

                simulationResultsView.OpenView(simulationResultsVM);
            }

            OnPropertyChanged(nameof(IsWorking));
        }

        #endregion

        #region Commands

        private ICommand createNewProject;

        public ICommand CreateNewProject => RelayCommand.Create(ref createNewProject, o =>
        {
            if(!manager.WhenClosing())
                return;

            manager.CreateNewProject();
            ProjectVM = new ProjectViewModel(manager.Project);
            OnPropertyChanged(nameof(ProjectVM));
        });

        private ICommand loadProject;

        public ICommand LoadProject => RelayCommand.Create(ref loadProject, o =>
        {
            if (!manager.WhenClosing())
                return;

            if (!manager.LoadProject())
                return;

            ProjectVM = new ProjectViewModel(manager.Project);
            OnPropertyChanged(nameof(ProjectVM));
        });

        private ICommand saveProject;

        public ICommand SaveProject => RelayCommand.Create(ref saveProject, o =>
        {
            manager.SaveProject();
        });

        private ICommand startSimulation;

        public ICommand StartSimulation => RelayCommand.Create(ref startSimulation, o =>
        {
            manager.SimulationDirector.StartSimulation(manager.Project);
        });

        #endregion

    }
}
