using System;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class MainViewModel : NotifyPropertyChanges, IViewModel
    {

        #region Constructors

        public MainViewModel(TeamworkSimulationManager manager, ServicesFactory servicesFactory, IOpenView simulationResultsView, IOpenView configurationView)
        {
            this.manager = manager;
            SimulationDirectorVM = new SimulationDirectorViewModel(manager.SimulationDirector, servicesFactory.CreateFileService(), this);

            manager.CreateNewProject();
            ProjectVM = new ProjectViewModel(manager.Project);

            manager.SimulationDirector.Started += SimulationDirector_IsWorkingChanged;
            manager.SimulationDirector.Stopped += SimulationDirector_IsWorkingChanged;

            this.simulationResultsView = simulationResultsView;
            this.configurationView = configurationView;
        }

        #endregion

        #region Private fields

        private readonly TeamworkSimulationManager manager;

        private readonly IOpenView simulationResultsView;
        private readonly IOpenView configurationView;

        private SimulationResultDirectorViewModel simulationResultDirectiorVM;

        #endregion

        #region Properties

        public IViewModel ParentViewModel { get; set; }

        public ProjectViewModel ProjectVM { get; private set; }

        public SimulationDirectorViewModel SimulationDirectorVM { get; }

        public bool IsWorking => manager.SimulationDirector.IsWorking;

        public bool CanShowResults => simulationResultDirectiorVM != null;

        #endregion

        #region Methods

        private void SimulationDirector_IsWorkingChanged(object sender, EventArgs e)
        {
            ShowSimulationResults();
            OnPropertyChanged(nameof(IsWorking));
        }

        private void LoadNewProject()
        {
            if (!manager.WhenClosing())
                return;

            if (!manager.LoadProject())
                return;

            ProjectVM = new ProjectViewModel(manager.Project);
            OnPropertyChanged(nameof(ProjectVM));
        }

        private void ShowSimulationResults()
        {
            if (!IsWorking)
            {
                simulationResultDirectiorVM = new SimulationResultDirectorViewModel(manager.SimulationDirector.ResultDirector, null);

                if (simulationResultsView.IsOpened)
                    simulationResultsView.CloseView();

                simulationResultsView.OpenView(simulationResultDirectiorVM);

                OnPropertyChanged(nameof(CanShowResults));
            }
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
            LoadNewProject();
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

        private ICommand showResults;

        public ICommand ShowResults => RelayCommand.Create(ref showResults, o =>
        {
            ShowSimulationResults();
        }, o => CanShowResults);

        private ICommand showConfiguration;

        public ICommand ShowConfiguration => RelayCommand.Create(ref showConfiguration, o =>
        {
            configurationView.OpenView(SimulationDirectorVM.EngineVM);
        });

        #endregion

    }
}
