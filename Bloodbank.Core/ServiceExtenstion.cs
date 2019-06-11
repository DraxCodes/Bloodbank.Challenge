using Bloodbank.Core.Providers;
using Bloodbank.Core.Services;
using Bloodbank.Core.SystemAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Bloodbank.Core
{
    public static class ServiceExtenstion
    {
        public static IServiceCollection UseBloodbankCore(this IServiceCollection services)
        {
            services
                .AddSingleton<IPersonService, PersonService>()
                .AddSingleton<IPersonProvider, PersonProvider>()
                .AddTransient<IConsole, Console>()
                .AddSingleton<ILogger, Logger>();
            return services;
        }
    }
}
