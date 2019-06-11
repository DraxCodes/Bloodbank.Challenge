namespace Bloodbank.Core.Services
{
    public interface ILogger
    {
        //TODO: Deprecate
        void Log(string message);
        void Write(string message);
    }
}
