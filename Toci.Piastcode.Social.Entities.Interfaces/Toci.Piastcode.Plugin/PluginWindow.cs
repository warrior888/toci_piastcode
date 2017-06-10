using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.Build.Construction;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Project = Microsoft.Build.Evaluation.Project;

namespace Toci.Piastcode.Plugin
{
    public class PluginWindow : Form
    {
        public PluginWindow()
        {
            StreamWriter swr = new StreamWriter(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Yuriy.cs");
            swr.Write("public class whatever {}");
            swr.Close();

            IVsSolution solution = Package.GetGlobalService(typeof(DTE)) as IVsSolution;
            
            //DTE dte = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.14.0");
            //solution.Projects.Item(0).ProjectItems.AddFromFile(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Yuriy.cs");

//            return;
            Project pr = new Project(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Toci.Piastcode.Tests.csproj");            

            pr.AddItem("Compile", @"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Yuriy.cs");
            pr.Save();

            pr.ReevaluateIfNecessary();
        }
    }
}