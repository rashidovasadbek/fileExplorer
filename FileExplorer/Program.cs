using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Infrastructure.FileStorage.Brokers;
using System.Reflection;
using FileExplorer.Configuration;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsync();

var app = builder.Build();

await app.ConfigureAsync();

await app.RunAsync();