using FluentMigrator;

namespace MMD_ECommerce.Logger.Service.Migrator.Migrations;

/// <summary>
/// Migration to create the initial 'Logs' table.
/// </summary>
[Migration(202406200001)] // Migration version based on timestamp
public class InitialTables_202406200001 : Migration
{
    /// <summary>
    /// Actions to be performed when rolling back the migration.
    /// </summary>
    public override void Down()
    {
        Delete.Table("Logs"); // Deletes the 'Logs' table if rolling back
        Execute.Sql(@"
                IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertLog')
                BEGIN
                    DROP PROCEDURE InsertLog;
                END
            ");
    }
    /// <summary>
    /// Actions to be performed when applying the migration.
    /// </summary>
    public override void Up()
    {
        // Creates the 'Logs' table with columns
        Create.Table("Logs")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Timestamp").AsDateTime().NotNullable()
            .WithColumn("ThreadId").AsInt32().NotNullable()
            .WithColumn("EventId").AsInt32().NotNullable()
            .WithColumn("EventName").AsString().Nullable()
            .WithColumn("Level").AsString().NotNullable()
            .WithColumn("Message").AsString(int.MaxValue).Nullable()
            .WithColumn("Exception").AsString().Nullable()
            .WithColumn("StackTrace").AsString(int.MaxValue).Nullable()
            .WithColumn("ExceptionMessage").AsString(int.MaxValue).Nullable()
            .WithColumn("Source").AsString(int.MaxValue).Nullable()
            .WithColumn("InnerException").AsString(int.MaxValue).Nullable();

        // Indexes for better query performance
        Create.Index("IX_LogEntities_Timestamp").OnTable("Logs").OnColumn("Timestamp");
        Create.Index("IX_LogEntities_Level").OnTable("Logs").OnColumn("Level");

        // Create stored procedure for inserting logs
        Execute.Sql(@"
                      CREATE PROCEDURE InsertLog
                          @Id UNIQUEIDENTIFIER,
                          @Timestamp DATETIME,
                          @Level NVARCHAR(MAX),
                          @Message NVARCHAR(MAX),
                          @Exception NVARCHAR(MAX),
                          @StackTrace NVARCHAR(MAX),
                          @ExceptionMessage NVARCHAR(MAX),
                          @Source NVARCHAR(MAX),
                          @InnerException NVARCHAR(MAX),
                          @ThreadId INT,
                          @EventId INT,
                          @EventName NVARCHAR(MAX)
                      AS
                      BEGIN
                          INSERT INTO Logs (Id, Timestamp, Level, Message, Exception, StackTrace, ExceptionMessage, Source, InnerException, ThreadId, EventId, EventName)
                          VALUES (@Id, @Timestamp, @Level, @Message, @Exception, @StackTrace, @ExceptionMessage, @Source, @InnerException, @ThreadId, @EventId, @EventName);
                      END");
    }
}

