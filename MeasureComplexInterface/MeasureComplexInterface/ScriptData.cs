using System.Diagnostics;
using System.IO;

namespace MeasureComplexInterface
{
    public class ScriptData
    {
        public string Response { get; private set; }
        public string ScriptPath { get; private set; }
        public string Arguments { get; set; }
        public string PythonPath => "C:/Program Files/Python35/python.exe";

        public ScriptData(string scriptPath, string args)
        {
            ScriptPath = scriptPath;
            Arguments = args;
        }
        public string GetData(int devType)
        {
            var response = string.Empty;
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = PythonPath,
                Arguments = string.Format("\"{0}\" \"{1}\"", ScriptPath, Arguments),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    Response = reader.ReadToEnd(); 
                }
            }
            return Response;
        }
    }
}
