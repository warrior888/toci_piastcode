using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toci.Piastcode.Plugin.Interfaces;
using Toci.Piastcode.Social.Client.Interfaces;
using Project = Microsoft.Build.Evaluation.Project;

namespace Toci.Piastcode.Plugin.Implementations
{
    public class ProjectFileManager : Package, IProjectFileManager
    {
        static Dictionary<string, Project> OpenProjectsMap = new Dictionary<string, Project>();

        public void AddNewFile(IProjectItem projectItem)
        {
            CreateAndFillWithContentFile(projectItem.FilePath, projectItem.Content);
            AddFileToProjest(projectItem.ProjectPath, projectItem.FilePath);
        }

        private void AddFileToProjest(string projectPath, string filePath)
        {
            Project pr;
            if (OpenProjectsMap.ContainsKey(projectPath))
            {
                pr = OpenProjectsMap[projectPath];
            }
            else
            {
                pr = new Project(projectPath);
                OpenProjectsMap.Add(projectPath, pr);
            }

            pr.ReevaluateIfNecessary();
            pr.DisableMarkDirty = true;

            pr.AddItem("Compile", filePath);
            pr.Save();

            
        }

        private void CreateAndFillWithContentFile(string filePath, string fileContent)
        {
            using (StreamWriter swr = new StreamWriter(filePath))
            {
                swr.Write(fileContent);
                swr.Close();
            }
        }
    }
}
