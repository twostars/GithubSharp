using System;

namespace GithubSharp.Core.Services.Implementation
{
    //TODO - untested/legacy - is this even what i want?
    public class NullLogger : ILogProvider
    {
        public NullLogger()
            : this(false)
        {
        }

        public NullLogger(bool Debug)
        {
            DebugMode = Debug;
        }

        public void LogMessage(string message, params object[] arguments)
        {
        }

        public void LogWarning(string message, params object[] arguments)
        {
        }

        public void LogError(Exception error)
        { }

        public bool DebugMode
        {
            get;
            set;
        }
    }


    public class ConsoleLogger : ILogProvider
    {
        public bool DebugMode { get; set; }

        public void LogMessage(string message, params object[] arguments)
        {
            Console.WriteLine(message, arguments);
        }

        public void LogWarning(string message, params object[] arguments)
        {
            Console.WriteLine(message, arguments);
        }

        public void LogError(Exception error)
        {
            LogMessage("Exception: " + error.Message);
        }
    }
}

