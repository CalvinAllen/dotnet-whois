using System.ComponentModel;

namespace CodingWithCalvin.WhoIs.Console.Models;

public enum SocialSites
{
    [Description("https://www.github.com")]
    GitHub,

    [Description("https://www.linkedin.com/in")]
    LinkedIn,

    [Description("https://www.twitter.com")]
    Twitter,

    [Description("https://www.twitch.tv")]
    Twitch
}