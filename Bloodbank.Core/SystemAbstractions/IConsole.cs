using System.Drawing;

namespace Bloodbank.Core.SystemAbstractions
{
    public interface IConsole
    {
        void WriteLine(string message, Color color);
        string ReadLine();
    }
}
