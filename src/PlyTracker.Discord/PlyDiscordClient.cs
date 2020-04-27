using Discord;
using Discord.WebSocket;
using PlyTracker.Core.Configuration;
using System;
using System.Threading.Tasks;

namespace PlyTracker.Discord
{
    public class PlyDiscordClient : IDiscord
    {
        private readonly IBotConfiguration _botConfig;

        public PlyDiscordClient(IBotConfiguration botConfig)
        {
            _botConfig = botConfig;
        }

        public DiscordSocketClient Client { get; private set; }

        public async Task InitializeAsync()
        {
            if (string.IsNullOrWhiteSpace(_botConfig.DiscordToken))
            {
                throw new ArgumentNullException(nameof(_botConfig.DiscordToken));
            }

            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info,
            });

            await Client.LoginAsync(TokenType.Bot, _botConfig.DiscordToken);
        }

        public void DisposeOfClient() => Client = null;
    }
}

