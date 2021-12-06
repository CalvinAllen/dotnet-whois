using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodingWithCalvin.WhoIs.Console.Models;

public class WhoModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("links")]
    public string[] Links { get; set; }

    [JsonPropertyName("social")]
    public IList<SocialModel> Social { get; set; } = new List<SocialModel>();
}

public class SocialModel
{
    [JsonPropertyName("site")]
    public SocialSites Site { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }
}