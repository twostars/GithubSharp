using System;

namespace GithubSharp.Core.Services
{
    //TODO - untested/legacy - is this even what i want?
    public interface ILogProvider
    {
        bool DebugMode { get; set; }
        void LogMessage(string message, params object[] arguments);
        void LogWarning(string message, params object[] arguments);
        void LogError(Exception error);
    }
    
}
