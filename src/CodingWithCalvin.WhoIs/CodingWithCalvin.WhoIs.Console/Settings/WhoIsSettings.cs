using Spectre.Console.Cli;

namespace CodingWithCalvin.WhoIs.Console.Settings;

public class WhoIsSettings : CommandSettings
{
    [CommandArgument(0, "[WHO]")]
    public string Who { get; set; }
}
