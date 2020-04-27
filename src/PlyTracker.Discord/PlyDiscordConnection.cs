using PlyTracker.Core.Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlyTracker.Discord
{
    public class PlyDiscordConnection : IDiscordConnection
    {
        private IDiscord _discord;
        public PlyDiscordConnection(IDiscord discord)
        {
            _discord = discord;
        }
        public async Task RunAsync(CancellationToken token)
        {
            try
            {
                await _discord.InitializeAsync();
                await _discord.Client.StartAsync();

                await Task.Delay(-1, token);
            }
            catch (Exception)
            {

                if (_discord.Client != null)
                {
                    await _discord.Client.LogoutAsync();
                    _discord.DisposeOfClient();
                }
            }
        }
    }
}
