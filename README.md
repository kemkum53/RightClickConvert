# Right Click Convert

This application created for simple convert proccesses. Currently, it only works with MP4 files.

## Installation
### Download
- [Download files](https://drive.google.com/file/d/1ri4Xgw-qq2PVcDTI_m44hOyh4rGzSJrh/view?usp=sharing) (If you want you can pull code, rebuild and run. Check Manuel Installation)
- Start 'RightClickConvert.exe' and finish installation.
- After installation right click .mp4 file and select convert. And you can convert any format what you want.
- Enjoy ^^

### Manuel Installation
- Pull code.
- Rebuild all solutions. If you got error and can't fix you can create a new issue.
- Publish both applications. With this settings ![image](https://github.com/kemkum53/RightClickConvert/blob/master/readme_files/ss_1.png?raw=true)
- Go to 'RightClickConvertApp' published folder location. And copy 'RightClickConvertApp.exe'.
- Now go to 'RightClickConvert' published folder location. Paste 'RightClickConvertApp.exe'
- Start as adminastrator 'RightClickConvert' and complate installation.

## Usage
- Right click the .mp4 file(If you are using Windows 10 or above, 'Shift + Right Click') and select 'Convert'. ![image](https://github.com/kemkum53/RightClickConvert/blob/master/readme_files/ss_2.png?raw=truE)
- Select what format you want to convert and press 'Convert' button. ![image](https://github.com/kemkum53/RightClickConvert/blob/master/readme_files/ss_3.png?raw=truE)
- Wait until the message box appears. Click 'Ok' and its done. ![image](https://github.com/kemkum53/RightClickConvert/blob/master/readme_files/ss_4.png?raw=truE)

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

## 🔗 Links
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/kemal-kondak%C3%A7%C4%B1-b62173157/)

