using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ILab.DependencyInjection
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write()
        {
            Debug.WriteLine("Testing dependency injection...");
        }
    }
}
