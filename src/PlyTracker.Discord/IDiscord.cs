using Discord.WebSocket;
using System.Threading.Tasks;

namespace PlyTracker.Discord
{
    public interface IDiscord
    {
        DiscordSocketClient Client { get; }

        Task InitializeAsync();

        void DisposeOfClient();
    }
}
