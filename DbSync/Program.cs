using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

Console.WriteLine("Hello World!");
var sourceConnString = "";
var destConnString = "";

const string eventsTable = "[Events]";
const string eventOrderingTable = "[EventOrdering]";
const string projectionHistoryTable = "[ProjectionHistory]";
const string snapshotEventsTable = "[SnapshotEvents]";

var observer = new DiagnosticSamples.DiagnosticObserver();
var subscription = DiagnosticListener.AllListeners.Subscribe(observer);

using (var conn = new SqlConnection(sourceConnString))
{
    conn.Open();
}
Console.WriteLine("Source connected!");
using (var conn = new SqlConnection(destConnString))
{
    await conn.OpenAsync();
    Console.WriteLine("Dest connected!");

    await TruncateDestTables(conn);
}

Console.WriteLine("All Good!");


static async Task TruncateDestTables(SqlConnection conn)
{
    Console.WriteLine("Truncate existing tables");
    var sql = $"TRUNCATE TABLE {eventsTable}; " +
        $"TRUNCATE TABLE {eventOrderingTable}; " +
        $"TRUNCATE TABLE {projectionHistoryTable}; " +
        $"TRUNCATE TABLE {snapshotEventsTable}; ";

    using (var cmd = new SqlCommand(sql, conn))
    {
        await cmd.ExecuteNonQueryAsync();
    }
}

public class EventDbContext : DbContext
{

}

public class Event
{
    public long Ordering { get; set; }
    public Guid EventId { get; set; }
    public DateTime Created { get; set; }
    public string EventType { get; set; }
    public string AggregateType { get; set; }
    public Guid AggregateId { get; set; }
    public int Version { get; set; }
    public string Payload { get; set; }
    public string Metadata { get; set; }
}
public class SnapshotOffer : Event
{
    public int SnapshotVersion { get; set; }
}

public class EventOrdering
{
    public string EventOrderingId { get; set; }
    public long CurrentOrdering { get; set; }
}