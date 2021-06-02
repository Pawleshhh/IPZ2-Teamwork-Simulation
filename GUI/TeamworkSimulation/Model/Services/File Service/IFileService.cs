using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public interface IFileService
    {

        string StartPath { get; set; }

        IDictionary<string, string> Extensions { get; }

        bool IsFile(string path);
        bool IsDirectory(string path);

        string OpenFile();
        string SaveFile();

        string[] OpenFiles();
        string[] SaveFiles();

        string OpenDirectory();
        string[] OpenDirectories(string path);

    }
}
