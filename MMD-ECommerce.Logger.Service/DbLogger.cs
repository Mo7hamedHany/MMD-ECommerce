using Dapper;
using MMD_ECommerce.Logger.Service.Contentxt;
using Microsoft.Extensions.Logging;

namespace MMD_ECommerce.Logger.Service;

public class DbLogger : ILogger
{

    private readonly DapperContext _context;
    public DbLogger( DapperContext context )
    {
        _context = context;
    }


    /// <summary>
    /// Begins a logical operation scope.
    /// </summary>
    IDisposable ILogger.BeginScope<TState>(TState state) => null!;


    /// <summary>
    /// Determines whether logging is enabled for the specified log level.
    /// </summary>
    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

    /// <summary>
    /// Logs the specified message and exception.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <param name="logLevel">An instance of <see cref="LogLevel"/>.</param>
    /// <param name="eventId">The event's ID. An instance of <see cref="EventId"/>.</param>
    /// <param name="state">The event's state.</param>
    /// <param name="exception">The event's exception. An instance of <see cref="Exception" /></param>
    /// <param name="formatter">A delegate that formats </param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {

        if (!IsEnabled(logLevel))
        {
            return; // Don't log the entry if it's not enabled.
        }

        var threadId = Thread.CurrentThread.ManagedThreadId; // Get the current thread ID to use in the log file. 

        using (var connection = _context.CreateConnection())
        {
            connection.Open();

            // Execute the stored procedure using Dapper
            connection.Execute("InsertLog",
                new
                {
                    Id = Guid.NewGuid(),
                    Timestamp = DateTime.Now,
                    Level = logLevel.ToString(),
                    Message = !string.IsNullOrWhiteSpace(formatter(state, exception)) ? formatter(state, exception) : null,
                    Exception = exception?.GetType().FullName,
                    StackTrace = exception?.StackTrace,
                    ExceptionMessage = exception?.Message,
                    Source = exception?.Source,
                    InnerException = exception?.InnerException?.ToString(),
                    ThreadId = threadId,
                    EventId = eventId.Id,
                    EventName = eventId.Name
                },
                commandType: System.Data.CommandType.StoredProcedure);

            connection.Close();
        }
    }
}

