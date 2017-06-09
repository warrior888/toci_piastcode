using System.IO;
using System.Speech.Recognition;
using Microsoft.Win32.SafeHandles;
using SpeechLib.Models;
using SpeechLib.Recognition;

namespace Toci.Piastcode.VoiceRecognition.Poc.Audio2Text
{
    public class MicPoc
    {
        public void MicPocTest()
        {
            SpeechRecognition sp = new SpeechRecognition();

            StreamReader sr = new StreamReader(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml");

            sp.LoadGrammar(sr.ReadToEnd().ToLower(), "exGrammar");

            sp.SpeechRecognitionEngine.SpeechDetected += SpeechRecognitionEngine_SpeechDetected;
            

            sp.SetInputToDefaultAudioDevice();
            sp.Recognized += HandleRecognition;
            sp.NotRecognized += Sp_NotRecognized;
            sp.Start();

            AudioState state = sp.SpeechRecognitionEngine.AudioState;
            //sp.Stop();
        }

        private void SpeechRecognitionEngine_SpeechDetected(object sender, System.Speech.Recognition.SpeechDetectedEventArgs e)
        {
            
        }

        private void Sp_NotRecognized(object sender, System.EventArgs e)
        {
            
        }

        public void HandleRecognition(object sender, SpeechRecognitionEventArgs e)
        {
            
        }
    }
}