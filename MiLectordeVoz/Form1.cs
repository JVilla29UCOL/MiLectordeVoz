using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Agregamos libreria
using System.Speech; //Agregamos la referencia
using System.Speech.Synthesis;

namespace MiLectordeVoz
{
    public partial class Form1 : Form
    {   
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reader.SpeakAsync(label1.Text);//Leemos el contenido
        }

        private void btnBDE_Click(object sender, EventArgs e)
        {
            Stream str;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if((str=openFileDialog.OpenFile()) != null)
                {
                    string fname = openFileDialog.FileName;
                    string filetxt = File.ReadAllText(fname);
                    label1.Text = filetxt;
                }
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if(reader!=null)
            {
                reader.Dispose();
            }
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            if(reader!=null)
            {
                if(reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(reader!=null)
            {
                if(reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }
        }
    }
}
