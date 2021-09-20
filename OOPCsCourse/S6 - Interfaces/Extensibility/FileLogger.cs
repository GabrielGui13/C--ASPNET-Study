using System;
using System.IO;

namespace Extensibility
{
    public class FileLogger : ILogger {
        private readonly string _path;

        public FileLogger(string path) {
            _path = path;
        }

        public void Log(string message, string messageType) {
            using (var streamWriter = new StreamWriter(_path, true)) {
                // there is an exception handling mechanism implicit, if something is wrong, the compiler will make sure to close file handle by calling Dispose();
                streamWriter.WriteLine(messageType + ": " + message);
                Console.WriteLine("finished");
            }
        }

        public void LogInfo(string message) {
            Log(message, "INFO");
        }

        public void LogError(string message) {
            Log(message, "ERROR");
        }
    }
}