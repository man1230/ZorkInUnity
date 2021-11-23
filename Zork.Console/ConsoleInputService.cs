using System;
using Zork.Common;

namespace Zork
{
    class ConsoleInputService : IInputService
    {
        public event EventHandler<string> InputReceived;

        public void ProcessInput()
        {
            string inputString = Console.ReadLine().Trim().ToUpper();
            InputReceived?.Invoke(this, inputString);
        }
    }
}
