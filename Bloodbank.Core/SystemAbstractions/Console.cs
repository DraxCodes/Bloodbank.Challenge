using System;
using System.Drawing;

namespace Bloodbank.Core.SystemAbstractions
{
    public class Console : IConsole
    {
        public void WriteLine(string message, Color color) => Colorful.Console.WriteLine(message, color);

        public string ReadLine() => Colorful.Console.ReadLine();
    }
}
