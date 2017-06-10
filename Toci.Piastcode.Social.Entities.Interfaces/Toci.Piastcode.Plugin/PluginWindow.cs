using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Build.Construction;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Project = Microsoft.Build.Evaluation.Project;
using Toci.Piastcode.Plugin.Implementations;
using Toci.Piastcode.Plugin.Interfaces;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;

namespace Toci.Piastcode.Plugin
{
    public class PluginWindow : Form
    {
        protected IProjectFileManager fileManager = new ProjectFileManager();

        //protected SocketClientManager scManager;



        public PluginWindow()
        {

            SocketClientManager scManager = new SocketClientManager("192.168.0.55", 25016, new Dictionary<ModificationType, Action<IItem>>
            {
                {ModificationType.Add, (item) => fileManager.AddNewFile((IProjectItem)item)},
            });

            scManager.StartClient();

            AddFile();
        }

        protected virtual void AddFile()
        {
            string filePath = @"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Yuriy.cs";
            string csProjPath = @"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Toci.Piastcode.Tests.csproj";
            string fileContent = "public class whatever {}";

            /*IProjectItem projItem = new ProjectItem(csProjPath, filePath, fileContent);
            projItem.ItemModificationType = ModificationType.Add;
            
            fileManager.AddNewFile(projItem);

            scManager.BroadCastFile(projItem);*/
        }
    }
}