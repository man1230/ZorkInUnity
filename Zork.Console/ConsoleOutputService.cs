using System;
using Zork.Common;

namespace Zork
{
    class ConsoleOutputService : IOutputService
    {
        public void Write(object value)
        {
            Console.Write(value);
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value);
        }
    }
}
