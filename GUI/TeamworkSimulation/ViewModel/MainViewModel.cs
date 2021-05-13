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

        private SimulationResultDirectorViewModel simulationResultDirectiorVM;

        #endregion

        #region Properties

        public ProjectViewModel ProjectVM { get; private set; }

        public bool IsWorking => manager.SimulationDirector.IsWorking;

        public bool CanShowResults => simulationResultDirectiorVM != null;

        public int Iterations
        {
            get => manager.SimulationDirector.Iterations;
            set => SetProperty(() => manager.SimulationDirector.Iterations == value, () => manager.SimulationDirector.Iterations = value);
        }

        public int MaximumIterations => manager.SimulationDirector.MaximumIterations;
        public int MinimumIterations => manager.SimulationDirector.MinimumIterations;

        public int SimulationCount
        {
            get => manager.SimulationDirector.SimulationCount;
            set => SetProperty(() => manager.SimulationDirector.SimulationCount == value, () => manager.SimulationDirector.SimulationCount = value);
        }

        public int MaximumSimulationCount => manager.SimulationDirector.MaximumSimulationCount;
        public int MinimumSimulationCount => manager.SimulationDirector.MinimumSimulationCount;

        public bool KeepPreviousResults
        {
            get => manager.SimulationDirector.KeepPreviousResults;
            set => SetProperty(() => manager.SimulationDirector.KeepPreviousResults == value, () => manager.SimulationDirector.KeepPreviousResults = value);
        }

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

        #endregion

    }
}
