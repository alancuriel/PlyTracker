using Microsoft.Extensions.DependencyInjection;
using PlyTracker.Core;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlyTracker.ConsoleApplication
{
    public class Program
    {
        private static DiscordBot _plyTrackerBot;
        static async Task Main(string[] args)
        {
            Console.Title = "PlyTracker";
            _plyTrackerBot = ActivatorUtilities.CreateInstance<DiscordBot>(InversionOfControl.Provider);

            if (!args.Any(arg => arg.StartsWith("-token=")))
            {
                Console.WriteLine("Requires token: -token=");
                Environment.Exit(0);
            }

            var token = args
                .First(arg => arg.StartsWith("-token="))
                .Substring(7);

            _plyTrackerBot.BotConfiguration.DiscordToken = token;
            await _plyTrackerBot.StartAsync();
        }
    }
}
