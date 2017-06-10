using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Build.Construction;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;
using Toci.Piastcode.Instructions.Entities;
using Toci.Piastcode.Instructions.Tools;
using Project = Microsoft.Build.Evaluation.Project;
using Toci.Piastcode.Plugin.Implementations;
using Toci.Piastcode.Plugin.Interfaces;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Implementations;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.SpeechRecognition.Tools;

namespace Toci.Piastcode.Plugin
{
    public class PluginWindow : Form
    {
        protected IProjectFileManager fileManager = new ProjectFileManager();
        private Button button1;
        private Button button2;
        private Button button3;
        protected SocketClientManager scManager;
        private IResult result;

        public PluginWindow()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            scManager = new SocketClientManager("192.168.0.55", 25016, new Dictionary<ModificationType, Action<IItem>>
            {
                {ModificationType.Add, (item) => fileManager.AddNewFile((IProjectItem)item)},
            });

            scManager.StartClient();
        }

        protected virtual void AddFile()
        {
            string filePath = @"..\..\..\..\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\"+ System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace("\\", "") +".cs";
            string csProjPath = @"..\..\..\..\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Toci.Piastcode.Tests.csproj";
            string fileContent = "public class GhostRider {}";

            IProjectItem projItem = new ProjectItem
            {
                Content = fileContent,
                FilePath = filePath,
                ProjectPath = csProjPath,
            };
            projItem.ItemModificationType = ModificationType.Add;
            
            fileManager.AddNewFile(projItem);

            scManager.BroadCastFile(projItem);
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(178, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "sound listen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PluginWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PluginWindow";
            this.ResumeLayout(false);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SpeechRecognitionManager mn = new SpeechRecognitionManager();

            mn.ManageVoiceInstructions(Parse);
        }

        protected virtual void Parse(string input)
        {
            Parser<ITarget, ISource, IResult> parser = new Parser<ITarget, ISource, IResult>();
            result = parser.Parse(null, new Source {StringSource = input});

            IDeveloperCommandDriver dcDriver = new DeveloperCommandDriver();
            IDevHandledInstruction instruction = dcDriver.CreateDevHandledInstruction(dcDriver.CommandDriver(result));

            IProjectItem projItem = new ProjectItem
            {
                Content = instruction.FileContent,
                FilePath = @"..\..\..\..\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\" + instruction.FileName + ".cs",
                ProjectPath = @"..\..\..\..\Toci.Piastcode.Social.Entities.Interfaces\Toci.Tests\Toci.Piastcode.Tests.csproj",
            };
            projItem.ItemModificationType = ModificationType.Add;

            fileManager.AddNewFile(projItem);

            scManager.BroadCastFile(projItem);
        }
    }
}