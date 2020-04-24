using System.Threading;
using System.Threading.Tasks;

namespace PlyTracker.Core.Discord
{
    public interface IDiscordConnection
    {
        Task RunAsync(CancellationToken token);
    }
}