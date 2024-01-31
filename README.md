# Right Click Convert

This application created for simple convert proccesses. Currently, it only works with MP4 files.

## Installation
### Download
1-) [Download files](https://drive.google.com/file/d/1ri4Xgw-qq2PVcDTI_m44hOyh4rGzSJrh/view?usp=sharing) (If you want you can pull code, rebuild and run.)

2-) Start 'RightClickConvert.exe' and finish installation.

3-) After installation right click .mp4 file and select convert. And you can convert any format what you want.

4-) Enjoy ^^

## Code Explanation
### RightClickConvert
This code add your regedit to right click event.
```csharp
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


 /*
  * This key registered for all files. Because when i tried to set only .mp4 files it didn't worked.
  */
string RightClickConvertAppPath = programFolder + @"\RightClickConvertApp.exe";
RegistryKey OpenProgramKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\Convert"); 
OpenProgramKey.SetValue("", "Convert");
OpenProgramKey.Close();
RegistryKey OpenProgramSubKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\Convert\command");
OpenProgramSubKey.SetValue("", "\"" + RightClickConvertAppPath + "\" " + "-i \"%1\"");
OpenProgramSubKey.Close();
```

### RightClickConvertApp
This code convert file to what format you want with using ffmpeg. 
```csharp
void Convert(string outputFile, string type)
{
    try
    {
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
                FileName = Program.ffmpegPath, //The ffmpegPath is set when the program is started.
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
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.
