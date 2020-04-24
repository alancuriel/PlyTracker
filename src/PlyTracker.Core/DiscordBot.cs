using PlyTracker.Core.Discord;
using PlyTracker.Core.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace PlyTracker.Core
{
    public class DiscordBot
    {
        private CancellationTokenSource _tokenSource;

        public IBotConfiguration BotConfiguration { get; }

        public IDiscordConnection DiscordConnection { get; }

        public IDiscordImpersonation Impersonation { get; }

        public DiscordBot(IDiscordConnection discordConnection, IBotConfiguration botConfig, IDiscordImpersonation impersonation)
        {
            DiscordConnection = discordConnection;
            BotConfiguration = botConfig;
            Impersonation = impersonation;
        }

        public async Task StartAsync()
        {
            _tokenSource = new CancellationTokenSource();
            await DiscordConnection.RunAsync(_tokenSource.Token);
        }

        public void Stop()
        {
            if (_tokenSource is null) { return; }
            _tokenSource.Cancel();
            _tokenSource.Dispose();
            _tokenSource = null;
        }
    }
}
