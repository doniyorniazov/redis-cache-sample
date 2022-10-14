// See https://aka.ms/new-console-template for more information

using System.Security.AccessControl;
using StackExchange.Redis;

string connectionString = "connection string";

var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
{
    return ConnectionMultiplexer.Connect(connectionString);
});

IDatabase cache = lazyConnection.Value.GetDatabase();

Console.WriteLine("Reading Cache : " + cache.StringGet("Session333"));
Console.WriteLine("Writing Cache : " + cache.StringSet("Session333","Writing something to Redis" + DateTime.Now.ToShortTimeString()));
Console.WriteLine("Reading Cache : " + cache.StringGet("Session333"));
cache.KeyExpire("Session333", DateTime.Now);

lazyConnection.Value.Dispose();

Console.WriteLine("Done!");
Console.ReadLine();