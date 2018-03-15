using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EboGuiTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static void CheckRunTimes()
        {
            string _filePath = "bump.";
            if (!File.Exists(_filePath))
                using (var wr = File.CreateText(_filePath))
                {
                    wr.Write(1);
                }
            else
            {
                var RunTime = 0;
                using (var rd = new StreamReader(_filePath))
                {
                    RunTime = int.Parse(rd.ReadLine());
                    if (RunTime >= 5)
                    {
                        MessageBox.Show(text: "Program exceeded trial period runs. Press enter to exit");
                        rd.Close();
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                }
                var wr = System.IO.File.CreateText(_filePath);
                wr.WriteLine(++RunTime);
                wr.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckRunTimes();
            /* this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = false;
            this.Text = ""; */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in OPF.FileNames)
                {
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = "ExternalHashing.exe";
                    myProcess.StartInfo.Arguments = file;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.Start();
                }
                string caption = "EBO has been created!";
                Thread.Sleep(2000);
                MessageBox.Show(caption);
            }           
        }


        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "ExternalHashing.exe";
                myProcess.StartInfo.Arguments = file;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.Start();
            }
            string caption = "EBO has been created!";
            Thread.Sleep(2000);
            MessageBox.Show(caption);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
