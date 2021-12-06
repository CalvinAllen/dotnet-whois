using CodingWithCalvin.WhoIs.Console.Commands;
using Spectre.Console.Cli;

namespace CodingWithCalvin.WhoIs.Console;

internal class Program 
{
    public static int Main(string[] args)
    {
        var app = new CommandApp<WhoIsCommand>();

        app.Configure(config =>
        {
            config.SetApplicationName("dotnet whois");
        });

        return app.Run(args);
    }
}
