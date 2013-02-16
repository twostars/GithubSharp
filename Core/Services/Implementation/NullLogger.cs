using System;

namespace GithubSharp.Core.Services.Implementation
{
    //TODO - untested/legacy - is this even what i want?
    public class NullLogger : ILogProvider
	{
		public NullLogger ()
			:this(false)
		{
		}

		public NullLogger (bool Debug)
		{
			DebugMode = Debug;
		}

		public void LogMessage (string Message, params object[] Arguments)
		{
		}

		public void LogWarning (string Message, params object[] Arguments)
		{
		}

		public bool HandleAndReturnIfToThrowError (Exception error)
		{
			return DebugMode;
		}

		public bool DebugMode {
			get;set;
		}
	}
    public class ConsoleLogger : GithubSharp.Core.Services.ILogProvider
	{
		public ConsoleLogger ()
			:this(false)
		{
		}

        public ConsoleLogger(bool Debug)
		{
			DebugMode = Debug;
		}

		public void LogMessage (string Message, params object[] Arguments)
		{
            Console.WriteLine(Message);
		}

		public void LogWarning (string Message, params object[] Arguments)
		{
            Console.WriteLine(Message);
		}

		public bool HandleAndReturnIfToThrowError (Exception error)
		{
			return DebugMode;
		}

		public bool DebugMode {
			get;set;
		}
	}
}

