using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeamworkSimulation.Model
{
    public class WindowsFileService : IFileService
    {

        #region Private fields


        #endregion

        #region Properties
        public string StartPath { get; set; } = "C:\\";

        public IDictionary<string, string> Extensions { get; } = new Dictionary<string, string>();
        #endregion

        #region Methods

        #endregion

        public bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public bool IsFile(string path)
        {
            return File.Exists(path);
        }

        public string OpenDirectory()
        {
            using(var folderBrowser = GetFolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() != DialogResult.OK)
                    return null;

                return folderBrowser.SelectedPath;
            }
        }

        public string[] OpenDirectories(string path)
        {
            if (!Directory.Exists(path))
                return null;

            return Directory.GetDirectories(path);
        }

        public string OpenFile()
        {
            using(var openFileDialog = GetOpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return null;

                return openFileDialog.FileName;
            }
        }
        public string SaveFile()
        {
            using (var saveFileDialog = GetSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return null;

                return saveFileDialog.FileName;
            }
        }

        public string[] OpenFiles()
        {
            using (var openFileDialog = GetOpenFileDialog(true))
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return null;

                return openFileDialog.FileNames;
            }
        }
        public string[] SaveFiles()
        {
            using (var saveFileDialog = GetSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return null;

                return saveFileDialog.FileNames;
            }
        }

        private string GetFilters()
            => string.Concat(Extensions.Select(kvp => $"{kvp.Value} (*.{kvp.Key})|*.{kvp.Key}"));

        private OpenFileDialog GetOpenFileDialog(bool multiselect = false, bool restore = true)
        {
            return new OpenFileDialog()
            {
                Filter = GetFilters(),
                Multiselect = multiselect,
                RestoreDirectory = restore,
                InitialDirectory = StartPath
            };
        }

        private SaveFileDialog GetSaveFileDialog()
        {
            return new SaveFileDialog()
            {
                Filter = GetFilters(),
                InitialDirectory = StartPath,
            };
        }

        private FolderBrowserDialog GetFolderBrowserDialog()
        {
            return new FolderBrowserDialog();
        }

    }
}
