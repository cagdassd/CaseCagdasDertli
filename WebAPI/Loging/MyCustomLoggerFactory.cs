﻿namespace WebAPI.Loging
{
	public class MyCustomLoggerFactory : ILoggerProvider
	{

		public ILogger CreateLogger(string categoryName)
		{
			return new MyCustomLogger();
		}
		public void Dispose()
		{
		}
	}

	public class MyCustomLogger : ILogger
	{
		public IDisposable? BeginScope<TState>(TState state) where TState : notnull
		{
			return null;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{

			string logMessage = formatter(state, exception);

			logMessage = $"[{DateTime.Now: dd.MM.yyyy HH:mm:ss}] - {logMessage}";

			Console.WriteLine(logMessage);
		}
	}
}
