using System;
using System.Diagnostics;

namespace RightClickConvertApp
{
    public partial class Form1 : Form
    {
        string inputFile, outputFile;
        private Process ffmpegProc;

        public Form1(bool isDetach, string inputFile)
        {
            InitializeComponent();
            this.inputFile = inputFile;
            //For size_reduction (canceled)
            if (isDetach)
            {
                Opacity = 0;
                ShowInTaskbar = false;
                outputFile = ChangeFileType(inputFile, ".mp4");
                Convert(outputFile, "mp4");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_type.SelectedIndex = 0;
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            try
            {
                btn_convert.Enabled = false;
                cmb_type.Enabled = false;
                switch (cmb_type.Text)
                {
                    case "mp4":
                        outputFile = ChangeFileType(inputFile, ".mp4");
                        Convert(outputFile, "mp4");
                        break;
                    case "mp4(h264)":
                        outputFile = ChangeFileType(inputFile, ".mp4");
                        Convert(outputFile, "mp4(h264)");
                        break;
                    case "mp4(h265)":
                        outputFile = ChangeFileType(inputFile, ".mp4");
                        Convert(outputFile, "mp4(h265)");
                        break;
                    case "mp4(mpeg4)":
                        outputFile = ChangeFileType(inputFile, ".mp4");
                        Convert(outputFile, "mp4(mpeg4)");
                        break;
                    case "avi":
                        outputFile = ChangeFileType(inputFile, ".avi");
                        Convert(outputFile, "avi");
                        break;
                    case "mp3":
                        outputFile = ChangeFileType(inputFile, ".mp3");
                        Convert(outputFile, "mp3");
                        break;
                    case "wav":
                        outputFile = ChangeFileType(inputFile, ".wav");
                        Convert(outputFile, "wav");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during installation. \n" + ex);
                Application.Exit();
            }
        }

        string ChangeFileType(string path, string type)
        {
            int lastIndex = path.LastIndexOf('.');
            return path.Substring(0, lastIndex) + "_converted" + type;
        }

        void Convert(string outputFile, string type)
        {
            try
            {
                //Add " to output and input files
                outputFile = "\"" + outputFile + "\"";
                inputFile = "\"" + inputFile + "\"";

                string args = "";

                if (type == "mp4")
                    args = "-i " + inputFile + outputFile;
                else if (type == "mp4(h264)")
                    args = "-i " + inputFile + " -c:v libx264 -c:a mp3 " + outputFile;
                else if (type == "mp4(h265)")
                    args = "-i " + inputFile + " -c:v libx265 -c:a mp3 " + outputFile;
                else if (type == "mp4(mpeg4)")
                    args = "-i " + inputFile + " -c:v mpeg4 -c:a mp3 " + outputFile;

                else if (type == "avi")
                    args = "-i " + inputFile + " -c:v copy -c:a copy " + outputFile;
                else if (type == "mp3")
                    args = "-i " + inputFile + " " + outputFile;
                else if (type == "wav")
                    args = "-i " + inputFile + " -ac 2 -f wav " + outputFile;


                ffmpegProc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Program.ffmpegPath,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        Arguments = args
                    }
                };
                ffmpegProc.Start(); 
                timer1.Start(); //Start timer and to wait process finish
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during installation. \n" + ex);
                Application.Exit();
            }
        }

        int i = 0;
        string proccessMessage = "Converting";
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                proccessMessage += ".";
                SetText(proccessMessage);
                if (i >= 4) { i = 0; proccessMessage = "Converting"; }
                i++;

                Process p = Process.GetProcessById(ffmpegProc.Id);
            }
            catch (Exception)
            {
                timer1.Stop();
                MessageBox.Show(outputFile + "\nCompleted");
                Application.Exit();
            }
        }

        public void SetText(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(SetText), new object[] { text });
                    return;
                }
                lbl_converting.Text = text;
            }
            catch (Exception) { }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                Process p = Process.GetProcessById(ffmpegProc.Id);
                if (p != null && !p.HasExited) p.Kill();
            }
            catch (Exception) { }
            finally
            {
                base.OnFormClosed(e);
            }
        }
    }
}
