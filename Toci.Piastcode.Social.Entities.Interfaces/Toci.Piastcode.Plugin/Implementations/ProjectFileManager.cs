using System.IO;
using Microsoft.Build.Evaluation;
using Toci.Piastcode.Plugin.Interfaces;
using Toci.Piastcode.Social.Client.Interfaces;

namespace Toci.Piastcode.Plugin.Implementations
{
    public class ProjectFileManager : IProjectFileManager
    {
        public void AddNewFile(IProjectItem projectItem)
        {
            CreateAndFillWithContentFile(projectItem.FilePath, projectItem.Content);
            AddFileToProjest(projectItem.ProjectPath, projectItem.FilePath);
        }

        private void AddFileToProjest(string projectPath, string filePath)
        {
            Project pr = new Project(projectPath);

            pr.AddItem("Compile", filePath);
            pr.Save();

            pr.ReevaluateIfNecessary();
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
