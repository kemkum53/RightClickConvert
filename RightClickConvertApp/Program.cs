using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RightClickConvertApp
{
    internal static class Program
    {
        public static string ffmpegPath;
        public static string fileType;
        static bool isDetach;
        static string inputFile;

        [STAThread]
        static void Main(string[] args = null)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if ((args == null || args.Length == 0) && !Debugger.IsAttached) return;
            //For test
            if (Debugger.IsAttached)
                args = new string[] { "-i", "asd.mp4" };

            ApplicationConfiguration.Initialize();
            Dictionary<string, string> arguments = ParseArguments(args); //Get arguments and convert to dict

            //For size_reduction (canceled)
            if (arguments.ContainsKey("-d"))
                isDetach = true;

            inputFile = arguments["-i"]; //Get input file full path
            string extension = Path.GetExtension(inputFile);
            fileType = extension.ToLower(new CultureInfo("en-gb"));
            if (!(extension.ToLower() != ".mp4" || extension.ToLower() == ".avi")) return; //TODO: only mp4 and avi this could be change(update avi format convert settings)
            
            //If file extension is .AVI replace with .avi
            if (extension == ".AVI")
                File.Move(inputFile, inputFile = inputFile.Replace(".AVI", ".avi"));

            ffmpegPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RightClickConvert\ffmpeg.exe"); //Get ffmpeg full path
            Application.Run(new Form1(isDetach, inputFile));
        }

        static Dictionary<string, string> ParseArguments(string[] args)
        {
            if (args == null) return null;
            Dictionary<string, string> arguments = new Dictionary<string, string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-") && i + 1 < args.Length && !args[i + 1].StartsWith("-"))
                {
                    string flag = args[i];
                    string value = args[i + 1];
                    arguments.Add(flag, value);
                    i++;
                }
                else if (args[i].StartsWith("-"))
                {
                    string flag = args[i];
                    arguments.Add(flag, null);
                }
            }
            return arguments;
        }
    }
}