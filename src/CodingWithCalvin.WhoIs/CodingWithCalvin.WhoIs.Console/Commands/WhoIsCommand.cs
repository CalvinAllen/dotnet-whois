using CodingWithCalvin.WhoIs.Console.Models;
using CodingWithCalvin.WhoIs.Console.Settings;
using CodingWithCalvin.WhoIs.Console.Extensions;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text;

namespace CodingWithCalvin.WhoIs.Console.Commands;

public class WhoIsCommand : AsyncCommand<WhoIsSettings>
{
    private static readonly HttpClient client = new();

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] WhoIsSettings settings)
    {
        var request = client.GetStreamAsync($"https://raw.githubusercontent.com/calvinallen/dotnet-whois/main/who/{settings.Who}.json");
        var who = await JsonSerializer.DeserializeAsync<WhoModel>(await request, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)}});
        
        if(who is null)
        {
            return -1;
        }

        var table = new Table();

        table.AddColumn("Name");
        table.AddColumn("Title");
        table.AddColumn("Social Links");

        table.AddRow(who.Name, FormatJob(who), CreateSocialTable(who));

        AnsiConsole.Write(table);

        return 0;
    }

    private static string FormatJob(WhoModel who)
    {
        if (string.IsNullOrEmpty(who.Company))
        {
            return who.Title;
        }

        return $"{who.Title} @ {who.Company}";
    }

    private static string CreateSocialTable(WhoModel who)
    {
        var sb = new StringBuilder();

        foreach (var social in who.Social) {
            sb.AppendLine($"{social.Site.ToDescription()}/{social.Username}");
        }

        sb.AppendLine();

        foreach(var link in who.Links)
        {
            sb.AppendLine($"{link}");
        }

        return sb.ToString().Trim();
    }
}

