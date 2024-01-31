using System.Diagnostics;

namespace RightClickConvertApp
{
    internal static class Program
    {
        public static string ffmpegPath;
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
            if (extension != ".mp4") return; //TODO: only mp4 this could be change

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