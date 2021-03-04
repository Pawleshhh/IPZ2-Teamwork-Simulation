using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using TeamworkSimulation.Model.Simulation;

namespace TeamworkSimulation.Model
{
    public class TeamworkSimulationManager
    {

        #region Constructors

        public TeamworkSimulationManager(ServicesFactory servicesFactory)
        {
            fileService = servicesFactory.CreateFileService();
            userMessageService = servicesFactory.CreateUserMessageService();
            projectSerializer = servicesFactory.CreateSerializer<Project>();

            fileService.Extensions.Add("tsp", "Teamwork Simulation Project");

            SimulationDirector = new PythonSimulationDirector();
        }

        #endregion

        #region Private fields

        private readonly IFileService fileService;
        private readonly IUserMessageService userMessageService;
        private readonly ISerializationService<Project> projectSerializer;

        #endregion

        #region Properties

        public Project Project { get; private set; } = new Project();
        public SimulationDirector SimulationDirector { get; }

        #endregion

        #region Methods

        public void CreateNewProject()
        {
            Project = new Project();
        }

        public bool LoadProject()
        {
            string path = fileService.OpenFile();
            if (string.IsNullOrEmpty(path))
                return false;

            Project = projectSerializer.LoadObject(path);

            return true;
        }

        public bool SaveProject()
        {
            string path = fileService.SaveFile();
            if (string.IsNullOrEmpty(path))
                return false;

            projectSerializer.SaveObject(Project, path);

            Project.UnsavedChanges = false;
            return true;
        }

        public bool WhenClosing()
        {
            if (!Project.UnsavedChanges)
                return true;

            var result = userMessageService.MessageUserWithResult("Unsaved changes", "Do you want to save your project before closing?", UserMessageType.Question, UserMessageOption.YesNoCancel);

            if (result == UserMessageResult.Yes)
            {
                SaveProject();
                return true;
            }
            else if (result == UserMessageResult.No)
            {
                SimulationDirector.Engine.Dispose();
                return true;
            }

            return false;
        }

        #endregion

    }
}
