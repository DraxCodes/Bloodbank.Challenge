using System.Drawing;
using Console = Colorful.Console;

namespace Bloodbank.Core.Services
{
    public class Logger : ILogger
    {
        private readonly Color _baseColor = Color.Cyan;

        public void Log(string message) => Write($"Log: {message}");

        public void Write(string message) => Console.WriteLine(message, _baseColor);
    }
}
