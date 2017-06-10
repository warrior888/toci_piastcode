using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.Piastcode.SpeechRecognition.Entities;
using Toci.Piastcode.VoiceRecognition.Poc.Audio2Text;

namespace Toci.Piastcode.VoiceRecognition.Poc.Front
{
    public partial class VrPoc : Form
    {
        public VrPoc()
        {
            InitializeComponent();

            Toci.Piastcode.SpeechRecognition.Tools.SpeechRecognition spR = new SpeechRecognition.Tools.SpeechRecognition();

            spR.GrammarSource = new GrammarSource { FilePath = @"Z:\Projects\TOCI_PiastCode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml" };


            spR.Listen();
            spR.RecognizeSpeech += s => Debug.WriteLine(s);

            //MicPoc poc = new MicPoc();

            //poc.ArbitrarySpeechRecognition();
            /*
            Button micStart = new Button();
            micStart.Text = "Start recording";
            micStart.Size = new Size(80, 20);
            micStart.Location = new Point(20, 20);
            micStart.Click += MicStart_Click;

            Controls.Add(micStart);*/
        }

        private void MicStart_Click(object sender, EventArgs e)
        {
            MicPoc poc = new MicPoc();

            poc.MicPocTest();
        }
    }
}
