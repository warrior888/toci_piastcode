using System.IO;
using System.Speech.Recognition;
using Microsoft.Win32.SafeHandles;
using SpeechLib.Models;
using SpeechLib.Recognition;
using System;
using System.Globalization;

namespace Toci.Piastcode.VoiceRecognition.Poc.Audio2Text
{
    public class MicPoc
    {
        public void MicPocTest()
        {
            SpeechRecognition sp = new SpeechRecognition();

            StreamReader sr = new StreamReader(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml");

            GrammarBuilder builder = new GrammarBuilder();

            Choices ch = new Choices("Erley", "play", "create", "public", "interface");

            builder.Append(ch);

            //sp.LoadGrammar(sr.ReadToEnd().ToLower(), "exGrammar");
            sp.LoadGrammar(new Grammar(builder));

            //sp.SpeechRecognitionEngine.c

            //sp.SpeechRecognitionEngine = new SpeechRecognitionEngine(CultureInfo.CurrentCulture);

            sp.SpeechRecognitionEngine.SpeechDetected += SpeechRecognitionEngine_SpeechDetected;
            

            sp.SetInputToDefaultAudioDevice();
            sp.Recognized += new EventHandler<SpeechRecognitionEventArgs>(Sp_Recognized); 
            sp.NotRecognized += Sp_NotRecognized;
            sp.Start();

            AudioState state = sp.SpeechRecognitionEngine.AudioState;
            //sp.Stop();
        }

        private void Sp_Recognized(object sender, SpeechRecognitionEventArgs e)
        {
            
        }

        private void SpeechRecognitionEngine_SpeechDetected(object sender, System.Speech.Recognition.SpeechDetectedEventArgs e)
        {
            
        }

        private void Sp_NotRecognized(object sender, System.EventArgs e)
        {
            
        }

        private void HandleRecognition(object sender, SpeechRecognitionEventArgs e)
        {
            
        }

        public void PureSpeechRecognitionTests()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            rec.SpeechRecognized += Rec_SpeechRecognized; ;
            rec.SetInputToDefaultAudioDevice();
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml");

                GrammarBuilder builder = new GrammarBuilder();

                Choices ch = new Choices("Erley", "play", "create", "public", "interface");

                builder.Append(ch);

                //sp.LoadGrammar(sr.ReadToEnd().ToLower(), "exGrammar");
                rec.LoadGrammar(new Grammar(builder));
               

                rec.SpeechDetected += SpeechRecognitionEngine_SpeechDetected;


                rec.SetInputToDefaultAudioDevice();

                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception e)
            {
            }
        }

        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
        }
    }
}