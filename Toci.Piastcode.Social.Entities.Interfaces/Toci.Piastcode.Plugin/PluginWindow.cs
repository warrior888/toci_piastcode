using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Build.Construction;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Project = Microsoft.Build.Evaluation.Project;
using Toci.Piastcode.Plugin.Interfaces;
using Toci.Piastcode.Plugin.Implementations;

namespace Toci.Piastcode.Plugin
{
    public class PluginWindow : Form
    {
        public PluginWindow()
        {
            string filePath = @"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Yuriy.cs";
            string csProjPath = @"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Toci.Piastcode.Tests.csproj";
            string fileContent = "public class whatever {}";
            //StreamWriter swr = new StreamWriter(filePath);
            //swr.Write(fileContent);
            //swr.Close();

            //Project pr = new Project(csProjPath);            

            //pr.AddItem("Compile", filePath);
            //pr.Save();

            //pr.ReevaluateIfNecessary();
            IProjectItem projItem = new ProjectItem(csProjPath,filePath, fileContent);
            IProjectFileManager fileManager = new ProjectFileManager();
            fileManager.AddNewFile(projItem);
        }
    }
}