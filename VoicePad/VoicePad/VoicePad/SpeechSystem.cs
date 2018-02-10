using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace VoicePad
{
    class SpeechSystem
    {
        //<WindowsForm Related Objects>
        VoicePad_Window vPW;    //Parent Form Object
        //<Speech-Related Objects>
        private SpeechRecognitionEngine listener;
        private SpeechSynthesizer speaker;
        bool speakerEnabled = true;
        //<Keywords>
        private List<string> keywords_complete = new List<string>();
        private List<string> keywords_std = new List<string>
        { "load", "register", "with", "immediate", "set", "from", "add", "subtract", "carry", "AND", "OR", "bit", "in", "out"};
        private List<string> keywords_hex = new List<string>
        { "zero", "one", "two", "three", "four", "five", "six","seven", "eight", "nine", "a", "b", "c", "d", "e", "f"};
        private Dictionary<string, string> dict_hex = new Dictionary<string, string>
        {
            { "zero", "0"}, {"one","1"}, {"two","2"},{"three","3"},{"four","4"},{"five","5"},{"six","6"},{"seven","7"},
            { "eight","8"},{"nine","9"},{"a","A"},{"b","B"},{"c","C"},{"d","D"},{"e","E"},{"f","F"}
        };
        private List<string> keywords_editor = new List<string>
        { "check", "cancel", "clear", "insert" };
        //<Syntactic Structure> >>RESERVED KEYS FOR INSERTING: "val", "n/a" <<
        private string[,] structures =
        {
            { "load", "register", "val", "with", "val", "n/a", "n/a", "n/a"},           //0: LDI [v1], [v2]
            { "load", "register", "val", "with", "register", "val", "n/a", "n/a" },     //1: MOV [v1], [v2]
            { "add", "register", "val", "with", "register", "val", "n/a", "n/a" },      //2: ADD [v1], [v2]
            { "subtract", "register", "val", "from", "register", "val", "n/a", "n/a" }, //3: SUB [v2], [v1]
            { "add", "with", "carry", "register", "val", "with", "val", "n/a" },        //4: ADC [v1], [v2]
            { "AND", "register", "val", "with", "register", "val", "n/a", "n/a"},       //5: AND [v1], [v2]
            { "OR", "register", "val", "with", "register", "val", "n/a", "n/a" },       //6: OR  [v1], [v2]
            { "set", "bit", "val", "in", "register", "val", "n/a", "n/a"},              //7: SBR [v2], [v1]
            { "clear", "bit", "val", "in", "register", "val", "n/a", "n/a" },           //8: CBR [v2], [v1]
            { "out", "val", "with", "register", "val", "n/a", "n/a", "n/a" },            //9: OUT [v1], [v2]
            { "in", "val", "with", "register", "val", "n/a", "n/a", "n/a" }              //10: IN [v1], [v2]
        };
        //<Other Variables>
        List<string> currentLine = new List<string>();   //Represents the Current Line of Text
        float confidenceSum = 0.0f;                      //Accumulated Confidence Level

        //<Speech Initializer>
        public void InitializeSpeech(VoicePad_Window vpw)
        {
            //Assign VPW
            vPW = vpw;
            //Initialize a New Listener
            listener = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            //Initialize a new Speaker
            speaker = new SpeechSynthesizer();
            //Setup Voice / Language
            speaker.SelectVoiceByHints(VoiceGender.Male);
            speaker.Rate = 1;
            //Setup Listening Audio Device
            listener.SetInputToDefaultAudioDevice();
            //Setup Events
            listener.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Event_SpeechRecognized);
            listener.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(Event_SpeechDetected);
            listener.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(Event_SpeechHypothesized);
            listener.AudioStateChanged += new EventHandler<AudioStateChangedEventArgs>(Event_AudioStateChanged);
            //Learn Keywords/Grammer, Load to Listener
            keywords_complete.AddRange(keywords_std);
            keywords_complete.AddRange(keywords_hex);
            keywords_complete.AddRange(keywords_editor);
            Choices keyChoices = new Choices(keywords_complete.ToArray());
            Grammar currentGrammar = new Grammar(new GrammarBuilder(keyChoices));
            listener.LoadGrammar(currentGrammar);
            //Start Listening to Speech
            listener.RecognizeAsync(RecognizeMode.Multiple);
            //Greet User
            speaker.SpeakAsync("Welcome to VoicePad, for AVR Assembly");
        }

        //<Speech Functional Events>
        public void SpeechInsert()
        {
            if (speakerEnabled) { speaker.SpeakAsyncCancelAll(); speaker.SpeakAsync("Inserted."); }
            vPW.Insert();
        }
        public void SpeechCheck()
        {
            //Attempt Recognizing the Line of Accumulated Keywords
            string output = RecognizeAsmLine(currentLine);
            vPW.UpdateAsmGuess(output);

            if (output != "Not Recognized")
            {
                //Speak for Validation of Spoken Line
                if (speakerEnabled) { speaker.SpeakAsync("My solution is" + vPW.GetAsmGuess()); }
            }
            else
            {
                if (speakerEnabled) { speaker.SpeakAsync("I do not think an instruction for that exists."); }
            }
        }
        public void SpeechClear()
        {
            //If Speaker is Speaking, Stop
            if (speakerEnabled) { speaker.SpeakAsyncCancelAll(); speaker.SpeakAsync("Cleared."); }
            //Clear the Current Line of Accumulated Keywords
            currentLine.Clear();    //Remove All Keywords From Line
            vPW.ClearVoiceBox();    //Clears On-Screen Voice Box
            vPW.ClearAsmGuess();    //Clears On-Screen Guess Box
        }

        //<Listener Events>
        protected void Event_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (keywords_complete.Contains(e.Result.Text))
            {
                //Increase Confidence Sum
                confidenceSum += e.Result.Confidence;
                //Determine Which Keyword was Spoken
                switch (e.Result.Text)
                {
                    case "insert":
                        SpeechInsert();
                        break;
                    case "check":
                        SpeechCheck();
                        break;
                    case "cancel":
                        SpeechClear();
                        break;
                    case "clear":
                        SpeechClear();
                        break;
                    default:
                        //Check for Spoken Hexadecimal Characters
                        if (keywords_hex.Contains(e.Result.Text))
                        {
                            //Ignore Hexadecimal Notation at Beginning of Line
                            if (currentLine.ToArray().Length == 0) { break; } 

                            //Check if Start of Hexadecimal Characters
                            if (!currentLine[currentLine.ToArray().Length - 1].Contains("0x"))
                            {
                                //Add Hexadecimal Notation (0x)
                                currentLine.Add("0x" + dict_hex[e.Result.Text]);     //Add to List of Keywords Detected
                                vPW.UpdateVoiceBox(currentLine);  //Send Immediate Result to On-Screen Voice Box
                            }
                            else
                            {
                                //Append Spoken Hexadecimal Character to Previous Characters
                                currentLine[currentLine.ToArray().Length - 1] += dict_hex[e.Result.Text];
                                vPW.UpdateVoiceBox(currentLine);  //Send Immediate Result to On-Screen Voice Box
                            }
                        }
                        else //Add Spoken Keyword to Line
                        {
                            //Normal Keyword Entry
                            currentLine.Add(e.Result.Text);   //Add to List of Keywords Detected
                            vPW.UpdateVoiceBox(currentLine);  //Send Immediate Result to On-Screen Voice Box
                        }
                        break;
                }
            }
        }
        protected void Event_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {

        }
        protected void Event_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {

        }
        protected void Event_AudioStateChanged(object sender, AudioStateChangedEventArgs e)
        {
        }

        //<Custom Speech Structure Recognition Functions>     
        string RecognizeAsmLine(List<string> keys)
        {
            //Setup a Buffer for Found Values for Each Structure
            List<string>[] foundValues = new List<string>[structures.GetLength(0)];
            for (int s = 0; s < structures.GetLength(0); s++) { foundValues[s] = new List<string>(); }
            //Assign All Matches as Being Possible
            bool[] pMatch = new bool[structures.GetLength(0)];
            for (int s = 0; s < structures.GetLength(0); s++) { pMatch[s] = true; }
            //Determine Number of Values That Must Be Found For Each Structure
            int[] numVals = new int[structures.GetLength(0)];
            for (int s = 0; s < structures.GetLength(0); s++)
            { for (int k = 0; k < structures.GetLength(1); k++) { if (structures[s, k] == "val") { numVals[s]++; } } }

            //Check for Potential Matches Among Syntax Structures
            for (int s = 0; s < structures.GetLength(0); s++)  
            {
                for (int k = 0; k < structures.GetLength(1); k++)
                {
                    //Only Check Matches That May Still be Possible
                    if (pMatch[s])
                    {
                        //Look for Completion Flag (Means Match is Correct)
                        if (structures[s, k] == "n/a" && numVals[s] == foundValues[s].ToArray().Length)
                        { return ConvertToAsm(s, foundValues[s]); }

                        if (k < keys.ToArray().Length)
                        { 
                            //Look for Hexadecimal Numbers (Values)
                            if (structures[s, k] == "val" && keys[k].Contains("0x")) { foundValues[s].Add(keys[k]); }
                            //Look for Invalid Matches, Flag Them for Removal From Search
                            else if (keys[k] != structures[s, k]) { pMatch[s] = false; }
                        }
                    }
                }
            }
            return "Not Recognized";
        }
        string ConvertToAsm(int sIndex, List<string> vals)
        {
            //Converter for AVR Assembly [HardCoded]
            switch (sIndex)
            {
                case 0: //LDI [v1], [v2]
                    return "LDI " + vals[0] + ", " + vals[1];
                case 1: //MOV [v1], [v2]
                    return "MOV " + vals[0] + ", " + vals[1];
                case 2: //ADD [v2], [v1]
                    return "ADD " + vals[0] + ", " + vals[1];
                case 3: //SUB [v2], [v1]
                    return "SUB " + vals[1] + ", " + vals[0];
                case 4: //ADC [v2], [v1]
                    return "ADC " + vals[0] + ", " + vals[1];
                case 5: //AND [v2], [v1]
                    return "AND " + vals[0] + ", " + vals[1];
                case 6: //OR [v2], [v1]
                    return "OR " + vals[0] + ", " + vals[1];
                case 7: //SBR [v2], [v1]
                    return "SBR " + vals[1] + ", " + vals[0];
                case 8: //CBR [v2], [v1]
                    return "CBR " + vals[1] + ", " + vals[0];
                case 9: //OUT [v1]
                    return "OUT " + vals[0] + ", " + vals[1];
                case 10: //IN [v1]
                    return "IN " + vals[1] + ", " + vals[0];
                default:
                    return "Language Error";
            }
        }
    }
}
