namespace Bloodbank.Core.Services
{
    public interface ILogger
    {
        void Log(string message);
        void Write(string message);
    }
}
