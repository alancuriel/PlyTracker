﻿namespace PlyTracker.Core.Configuration
{
    public interface IBotConfiguration
    {
        bool CommandsEnabled { get; set; }

        string DiscordToken { get; set; }
    }
}