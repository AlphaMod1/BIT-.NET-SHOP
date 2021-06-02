using Shop2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Loggers
{
    class ConsoleLogger : ILogger
    {
        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}
