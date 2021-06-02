using Shop2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Loggers
{
    class FileLogger : ILogger
    {
        private readonly string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
            File.WriteAllText(_filePath, "");
        }
        public void Write(string input)
        {
            File.AppendAllText(_filePath, input + "\n");
        }
    }
}
