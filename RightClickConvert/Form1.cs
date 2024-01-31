using Microsoft.Win32;

namespace RightClickConvert;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void chb_confirm_CheckedChanged(object sender, EventArgs e)
    {
        if (chb_confirm.Checked)
            btn_start.Enabled = true;
        else
            btn_start.Enabled = false;
    }

    private async void btn_start_Click(object sender, EventArgs e)
    {
        btn_start.Enabled = false;
        await Task.Run(StartInstall);
    }

    void StartInstall()
    {
        try
        {
            //Get %appdata% folder
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //Create 'RightClickConvert' if folder dosen't exist
            string programFolder = Path.Combine(appDataFolderPath, "RightClickConvert");
            if (!Directory.Exists(programFolder))
            {
                Directory.CreateDirectory(programFolder);
            }
            Progress(4);
            //Copy 'ffmpeg.exe' and 'RightClickConvertApp.exe' files to %appdata% folder
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg.exe"), programFolder + "\\ffmpeg.exe", true);
            File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RightClickConvertApp.exe"), programFolder + "\\RightClickConvertApp.exe", true);


            //For size_reduction (canceled)
            //RegistryKey Convertkey = Registry.ClassesRoot.CreateSubKey(@"*\shell\SizeReduction"); //TODO: only mp4 this could be change
            //Convertkey.SetValue("", "Size Reduction");
            //Convertkey.Close();
            //RegistryKey ConvertSubKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\SizeReduction\command");
            //ConvertSubKey.SetValue("", "\"" + RightClickConvertAppPath + "\" " + "-d -i \"%1\"");
            //ConvertSubKey.Close();

            Progress(8);

            string RightClickConvertAppPath = programFolder + @"\RightClickConvertApp.exe";

            /*
             * This key registered for all files. Because when i tried to set only .mp4 files it didn't worked.
             */

            //Set key to regedit
            RegistryKey OpenProgramKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\Convert"); //TODO: only mp4 this could be change
            OpenProgramKey.SetValue("", "Convert");
            OpenProgramKey.Close();
            RegistryKey OpenProgramSubKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\Convert\command");
            OpenProgramSubKey.SetValue("", "\"" + RightClickConvertAppPath + "\" " + "-i \"%1\"");
            OpenProgramSubKey.Close();

            Progress(10);
            MessageBox.Show("Installation Completed.");
            Application.Exit();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred during installation. \n" + ex);
            Application.Exit();
        }
    }

    public void Progress(int i)
    {
        try
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(Progress), new object[] { i });
                return;
            }
            prg_progress.Value = i * 10;
        }
        catch (Exception) { }
    }
}
