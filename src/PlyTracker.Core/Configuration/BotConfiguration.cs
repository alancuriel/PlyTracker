using System;
using System.Collections.Generic;
using System.Text;

namespace PlyTracker.Core.Configuration
{
    public class BotConfiguration : IBotConfiguration
    {
        public bool CommandsEnabled { get; set; } = false;
        public string DiscordToken { get; set; }
    }
}
