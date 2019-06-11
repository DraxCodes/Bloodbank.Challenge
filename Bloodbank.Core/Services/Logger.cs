using System.Drawing;
using Bloodbank.Core.SystemAbstractions;

namespace Bloodbank.Core.Services
{
    public class Logger : ILogger
    {
        private IConsole _console;
        public Logger(IConsole console)
        {
            _console = console;
        }

        private readonly Color _baseColor = Color.Cyan;
        private readonly  Color _logColor = Color.Firebrick;
        public void Log(string message) => _console.WriteLine($"Log: {message}", _logColor);

        public void Write(string message) => _console.WriteLine(message, _baseColor);
    }
}
