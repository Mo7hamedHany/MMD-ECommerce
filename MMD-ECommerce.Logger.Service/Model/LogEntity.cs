using Microsoft.Extensions.Logging;

namespace MMD_ECommerce.Logger.Service.Model;

/// <summary>
/// Entity representing a log entry stored in the database.
/// </summary>
public class LogEntity
{
    /// <summary>
    /// Unique identifier for the log entry.
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Identifier for the thread associated with the log entry.
    /// </summary>
    public int ThreadId { get; set; }

    /// <summary>
    /// Identifier for the event associated with the log entry.
    /// </summary>
    public int EventId { get; set; }

    /// <summary>
    /// Name of the event associated with the log entry.
    /// </summary>
    public string? EventName { get; set; }

    /// <summary>
    /// Timestamp when the log entry was created.
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Severity level of the log entry (e.g., Error, Warning, Information).
    /// </summary>
    public LogLevel Level { get; set; }

    /// <summary>
    /// Log message describing the event or error.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Full name of the exception type if the log entry represents an exception.
    /// </summary>
    public string? Exception { get; set; }

    /// <summary>
    /// Stack trace of the exception if the log entry represents an exception.
    /// </summary>
    public string? StackTrace { get; set; }

    /// <summary>
    /// Message of the exception if the log entry represents an exception.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Source of the exception if the log entry represents an exception.
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// Inner exception details if the log entry represents an exception with an inner exception.
    /// </summary>
    public string? InnerException { get; set; }
}