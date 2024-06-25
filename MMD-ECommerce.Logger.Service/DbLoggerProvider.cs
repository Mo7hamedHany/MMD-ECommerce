using MMD_ECommerce.Logger.Service.Contentxt;
using Microsoft.Extensions.Logging;

namespace MMD_ECommerce.Logger.Service;

[ProviderAlias("Database")]
public class DbLoggerProvider : ILoggerProvider
{
    private readonly DapperContext _context;

    public DbLoggerProvider( DapperContext context )
    {
        _context = context;

    }
    /// <summary>
    /// Creates a new instance of the db logger.
    /// </summary>
    /// <param name="categoryName"></param>
    /// <returns></returns>
    public ILogger CreateLogger(string categoryName)
    {
        return new DbLogger( _context );
    }

    public void Dispose()
    {
    }
}

