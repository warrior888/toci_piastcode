﻿using System.IO;
using System.Speech.Recognition;
using Microsoft.Win32.SafeHandles;
using SpeechLib.Models;
using SpeechLib.Recognition;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Speech.Recognition.SrgsGrammar;

namespace Toci.Piastcode.VoiceRecognition.Poc.Audio2Text
{
    public class MicPoc
    {
        public void MicPocTest()
        {
            SpeechRecognition sp = new SpeechRecognition();

            StreamReader sr = new StreamReader(@"Z:\Projects\TOCI_PiastCode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml");

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

        public void ArbitrarySpeechRecognition()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            rec.SpeechRecognized += Rec_SpeechRecognized; ;
            rec.SetInputToDefaultAudioDevice();

            try
            {
                rec.LoadGrammar(GetXmlGrammar());              

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
            Debug.WriteLine(e.Result.Text);
        }

        private void SpeechRecognitionEngine_SpeechDetected(object sender, System.Speech.Recognition.SpeechDetectedEventArgs e)
        {

        }

        private Grammar GetGrammar()
        {
            Choices commandtype = new Choices();
            commandtype.Add("create");
            commandtype.Add("public");
            commandtype.Add("interface");
            commandtype.Add("class");

            SemanticResultKey srkComtype = new SemanticResultKey("comtype", commandtype.ToGrammarBuilder());

            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            gb.Append(srkComtype);
            gb.AppendDictation();

            return new Grammar(gb);
        }

        private Grammar GetXmlGrammar()
        {
            //StreamReader sr = new StreamReader(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml");

            return new Grammar(new SrgsDocument(@"C:\Users\bzapart\Documents\toci_piastcode\Toci.Piastcode.Social.Entities.Interfaces\Toci.Piastcode.VoiceRecognition.Poc\data\grammar.xml")); 
        }
    }
}