using System;

namespace GithubSharp.Core.Services
{
    //TODO - untested/legacy - is this even what i want?
    public interface ILogProvider
    {
        bool DebugMode { get; set; }
        void LogMessage(string Message, params object[] Arguments);
        void LogWarning(string Message, params object[] Arguments);
        bool HandleAndReturnIfToThrowError(Exception error);
    }
}
