using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.ViewModel
{
    public class PythonSimulationEngineViewModel : NotifyPropertyChanges, IViewModel
    {

        #region Constructors

        public PythonSimulationEngineViewModel(PythonSimulationEngine engine, IFileService fileService, IViewModel parent = null)
        {
            ParentViewModel = parent;

            pyEngine = engine;
            this.fileService = fileService;

            LoadPyLibs();
        }

        #endregion

        #region Private fields

        private PythonSimulationEngine pyEngine;
        private IFileService fileService;

        private readonly ObservableCollection<string> libraries = new ObservableCollection<string>();

        #endregion

        #region Properties

        public IViewModel ParentViewModel { get; set; }

        public string PythonPath
        {
            get => pyEngine.PythonPath;
            private set => SetProperty(() => pyEngine.PythonPath == value, () => pyEngine.PythonPath = value);
        }

        public string ModuleName
        {
            get => pyEngine.ModuleName;
            set => SetProperty(() => pyEngine.ModuleName == value, () => pyEngine.ModuleName = value);
        }

        public ReadOnlyObservableCollection<string> LibNames { get; private set; }

        #endregion

        #region Methods

        private void SetPythonPath()
        {
            PythonPath = fileService.OpenDirectory();
            LoadPyLibs();
        }

        private void LoadPyLibs()
        {
            if (string.IsNullOrEmpty(PythonPath))
                return;

            libraries.Clear();

            string[] dirs = fileService.OpenDirectories(PythonPath + "\\Lib");

            if (dirs == null)
                return;

            foreach (var dir in dirs)
                libraries.Add(Path.GetFileName(dir));

            LibNames = new ReadOnlyObservableCollection<string>(libraries);
            OnPropertyChanged(nameof(LibNames));
        }

        #endregion

        #region Commands

        private ICommand selectPythonPath;

        public ICommand SelectPythonPath => RelayCommand.Create(ref selectPythonPath, o =>
        {
            SetPythonPath();
        });

        private ICommand refreshLibraries;

        public ICommand RefreshLibraries => RelayCommand.Create(ref refreshLibraries, o =>
        {
            LoadPyLibs();
        });

        #endregion
    }
}
