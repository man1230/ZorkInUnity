using System;
using System.Collections.Generic;
using System.Text;

namespace Zork.Common
{
    public interface IInputService
    {
        event EventHandler<string> InputReceived;
    }
}
