using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Extensions.DependencyInjection;
using PlyTracker.Core;
using PlyTracker.Core.Attributes;
using PlyTracker.Core.Configuration;
using PlyTracker.Core.Discord;
using PlyTracker.Core.Entities;
using PlyTracker.Discord;

namespace PlyTracker.InversionOfControl
{
    public static class Container
    {
        public static IServiceCollection AddBotTypes(this IServiceCollection collection)
                => collection.AddSingleton<IBotConfiguration, BotConfiguration>()
            .AddSingleton<IDiscordConnection, PlyDiscordConnection>()
            .AddSingleton<IDiscord, PlyDiscordClient>()
            .AddSingleton<IDiscordImpersonation, DiscordImpersonation>()
            .AddBotServices();

        private static IServiceCollection AddBotServices(this IServiceCollection collection)
        {
            var serviceAttributeType = typeof(ServiceAttribute);
            var serviceTypes = Assembly.GetAssembly(serviceAttributeType)
                                       .GetTypes()
                                       .Where(x => x.GetCustomAttributes(serviceAttributeType, true).Length > 0).ToList();

            serviceTypes.ForEach((x) =>
            {
                var attribute = x.GetCustomAttribute(serviceAttributeType) as ServiceAttribute;
                switch (attribute.ServiceType)
                {
                    case ServiceType.SCOPED:
                        _ = collection.AddScoped(x);
                        break;
                    case ServiceType.SINGLETON:
                        _ = collection.AddSingleton(x);
                        break;
                    case ServiceType.TRANSIENT:
                        _ = collection.AddTransient(x);
                        break;
                    default:
                        break;
                }
            });

            return collection;
        }
    }
}
