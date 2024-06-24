using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace MMD_ECommerce.Logger.Service.Contentxt;

/// <summary>
/// Provides methods to create database connections using Dapper.
/// </summary>
public class DapperContext
{
    private readonly IConfiguration _configuration;
    public DapperContext( IConfiguration configuration )
    {
        _configuration = configuration;
    }
    /// <summary>
    /// Creates and returns a new connection to the logger database.
    /// </summary>
    /// <returns>A new <see cref="IDbConnection"/> to the logger database.</returns>
    public IDbConnection CreateConnection() => new SqlConnection( _configuration.GetConnectionString("LoggerConnection"));

    /// <summary>
    /// Creates and returns a new connection to the master database.
    /// </summary>
    /// <returns>A new <see cref="IDbConnection"/> to the master database.</returns>
    public IDbConnection CreateMasterConnection() => new SqlConnection( _configuration.GetConnectionString("MasterConnection"));
}

