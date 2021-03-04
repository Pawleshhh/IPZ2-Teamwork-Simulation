using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public abstract class ProjectItemViewModel : NotifyPropertyChanges, IViewModel
    {
        #region Constructors

        protected ProjectItemViewModel(IProjectItem projectItem)
        {
            this.projectItem = projectItem ?? throw new ArgumentNullException(nameof(projectItem));

            projectItemVMs = new ObservableCollection<ProjectItemViewModel>();
            ProjectItemVMs = new ReadOnlyObservableCollection<ProjectItemViewModel>(projectItemVMs);

            ColorVM = new ColorViewModel(projectItem.Color);
        }

        #endregion

        #region Private fields

        private readonly IProjectItem projectItem;

        private ObservableCollection<ProjectItemViewModel> projectItemVMs;

        private bool renameModeOn;

        //private bool isSelected;

        #endregion

        #region Properties

        public IViewModel ParentViewModel { get; set; }

        //public bool IsSelected
        //{
        //    get => isSelected;
        //    set => SetProperty(() => isSelected == value, () => isSelected = value);
        //}

        public string ItemName
        {
            get => projectItem.ItemName;
            set => SetProperty(() => projectItem.ItemName == value, () => projectItem.ItemName = value);
        }

        public ReadOnlyObservableCollection<ProjectItemViewModel> ProjectItemVMs { get; private set; }

        public bool RenameModeOn
        {
            get => renameModeOn;
            set => SetProperty(() => renameModeOn == value, () => renameModeOn = value);
        }

        public ColorViewModel ColorVM { get; }

        #endregion

        #region Methods

        //protected void UpdateProjectItems()
        //{
        //    projectItemVMs = new ObservableCollection<ProjectItemViewModel>(
        //        projectItem.GetProjectItems().Select(n => new ProjectItemViewModel(n)));

        //    ProjectItemVMs = new ReadOnlyObservableCollection<ProjectItemViewModel>(projectItemVMs);

        //    OnPropertyChanged(nameof(ProjectItemVMs));
        //}

        protected void AddProjectItem(ProjectItemViewModel projectItemVM)
            => projectItemVMs.Add(projectItemVM);

        protected void RemoveProjectItem(int index)
            => projectItemVMs.RemoveAt(index);

        protected void ClearProjectItems()
            => projectItemVMs.Clear();

        protected void ApplyColorToAllItems()
        {
            projectItem.ApplyColor();
        }

        #endregion

        #region Commands

        private ICommand renameOn;

        public ICommand RenameOn => RelayCommand.Create(ref renameOn, o =>
        {
            RenameModeOn = true;
        });

        private ICommand renameOff;

        public ICommand RenameOff => RelayCommand.Create(ref renameOff, o =>
        {
            RenameModeOn = false;
        });

        private ICommand applyColor;

        public ICommand ApplyColor => RelayCommand.Create(ref applyColor, o => ApplyColorToAllItems());

        //private ICommand select;

        //public ICommand Select => RelayCommand.Create(ref select, o =>
        //{
        //    IsSelected = (bool)o;
        //});

        #endregion

    }
}
