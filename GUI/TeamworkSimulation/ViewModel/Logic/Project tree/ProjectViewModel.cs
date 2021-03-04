﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class ProjectViewModel : ProjectItemViewModel
    {

        #region Constructors

        public ProjectViewModel(Project project)
            :base(project)
        {
            this.project = project ?? throw new ArgumentNullException(nameof(project));

            workplaceVMs = new ObservableCollection<WorkplaceViewModel>(
                project.Workplaces.Select(n => new WorkplaceViewModel(n)));
            WorkplaceVMs = new ReadOnlyObservableCollection<WorkplaceViewModel>(workplaceVMs);

            WorkplaceTemplateVM = new WorkplaceTemplateViewModel(project.WorkplaceTemplateBuilder);

            project.Added += Project_Added;
            project.Removed += Project_Removed;
            project.Cleared += Project_Cleared;
        }

        #endregion

        #region Private fields

        private readonly Project project;

        private ObservableCollection<WorkplaceViewModel> workplaceVMs;

        #endregion

        #region Properties

        public bool UnsavedChanges
        {
            get => project.UnsavedChanges;
        }

        public string ProjectName
        {
            get => project.ProjectName;
            set => SetProperty(() => project.ProjectName == value, () => project.ProjectName = value);
        }

        public ReadOnlyObservableCollection<WorkplaceViewModel> WorkplaceVMs { get; private set; }

        public int CurrentWorkplace
        {
            get => project.CurrentWorkplace;
            set
            {
                if(SetProperty(() => project.CurrentWorkplace == value, () => project.CurrentWorkplace = value))
                    OnPropertyChanged(nameof(SelectedWorkplaceVM));
            }
        }

        public WorkplaceViewModel SelectedWorkplaceVM
            => workplaceVMs.Count > 0 ? WorkplaceVMs[CurrentWorkplace] : null;

        public WorkplaceTemplateViewModel WorkplaceTemplateVM { get; }

        #endregion

        #region Methods

        public void Add()
        {
            project.AddWorkplace();

            CurrentWorkplace = workplaceVMs.Count - 1;
            OnPropertyChanged(nameof(SelectedWorkplaceVM));
        }

        public void Remove(int index)
        {
            project.RemoveWorkplaceAt(index);

            if(workplaceVMs.Count == 0)
                OnPropertyChanged(nameof(SelectedWorkplaceVM));
        }

        public void Clear()
        {
            project.ClearWorkplaces();
            OnPropertyChanged(nameof(SelectedWorkplaceVM));
        }

        private void Project_Added(object sender, DataEventArgs<(int, IWorkplace)> e)
        {
            WorkplaceViewModel workplaceViewModel = new WorkplaceViewModel(e.Value.Item2) { ParentViewModel = this };
            workplaceVMs.Add(workplaceViewModel);
            AddProjectItem(workplaceViewModel);
        }

        private void Project_Removed(object sender, DataEventArgs<(int, IWorkplace)> e)
        {
            workplaceVMs.RemoveAt(e.Value.Item1);
            RemoveProjectItem(e.Value.Item1);
        }

        private void Project_Cleared(object sender, EventArgs e)
        {
            workplaceVMs.Clear();
            ClearProjectItems();
        }

        #endregion

        #region Commands

        private ICommand addWorkplace;

        public ICommand AddWorkplace => RelayCommand.Create(ref addWorkplace, o => Add());

        private ICommand removeWorkplace;

        public ICommand RemoveWorkplace => RelayCommand.Create(ref removeWorkplace, o =>
        {
            if(o is WorkplaceViewModel w)
            {
                int index = workplaceVMs.IndexOf(w);
                Remove(index);
            }
        });

        private ICommand clearWorkplaces;

        public ICommand ClearWorkplaces => RelayCommand.Create(ref clearWorkplaces, o => Clear());

        private ICommand changeCurrentWorkplace;

        public ICommand ChangeCurrentWorkplace => RelayCommand.Create(ref changeCurrentWorkplace, o =>
        {
            if(o is WorkplaceViewModel w)
            {
                int index = workplaceVMs.IndexOf(w);
                CurrentWorkplace = index;
            }
        });

        #endregion

    }
}
