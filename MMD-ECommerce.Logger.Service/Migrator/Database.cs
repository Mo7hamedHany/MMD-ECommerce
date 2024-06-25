using Dapper;
using MMD_ECommerce.Logger.Service.Contentxt;


namespace MMD_ECommerce.Logger.Service.Migrator;

/// <summary>
/// Provides methods to manage database creation and migration.
/// </summary>
public class Database
{
    private readonly DapperContext _context;
    public Database( DapperContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new database if it does not already exist.
    /// </summary>
    /// <param name="dbName">The name of the database to create.</param>
    public void CreateDatabase(string dbName)
    {
        const string query = "SELECT * FROM sys.databases WHERE name = @name";

        var parameters = new DynamicParameters();

        parameters.Add("name", dbName);

        using (var connection = _context.CreateMasterConnection())
        {
            var records = connection.Query(query, parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {dbName}");
            }
        }
    }
}
