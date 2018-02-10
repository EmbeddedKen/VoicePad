using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace VoicePad
{
    public partial class VoicePad_Window : Form
    {
        SpeechSystem speechSys = new SpeechSystem();

        //<Windows Forms Initializer>
        public VoicePad_Window()
        {
            InitializeComponent();
            speechSys.InitializeSpeech(this);
        }

        public void UpdateVoiceBox(List<string> words)
        {
            VoiceBox.Text = "";
            for (int i = 0; i < words.ToArray().Length; i++)
            {
                VoiceBox.Text += words[i] + " ";
            }
        }
        public void ClearVoiceBox() { VoiceBox.Text = ""; }
        public string GetVoiceBox() { return VoiceBox.Text; }
        public void UpdateAsmGuess(string s) { AsmBox.Text = s; }
        public string GetAsmGuess() { return AsmBox.Text; }
        public void ClearAsmGuess() { AsmBox.Text = ""; }
        public void Insert()
        {
            //Add Text to Page if Not Empty
            if (AsmBox.Text != "")
            {
                FileBox.AppendText(AsmBox.Text + Environment.NewLine);
                commentBox.AppendText(VoiceBox.Text + Environment.NewLine);
            }
        }
        private void InsertBtn_Click(object sender, EventArgs e) { speechSys.SpeechInsert(); }
        private void checkBtn_Click(object sender, EventArgs e) { speechSys.SpeechCheck(); }
        private void clearBtn_Click(object sender, EventArgs e) { speechSys.SpeechClear(); }
    }
}
