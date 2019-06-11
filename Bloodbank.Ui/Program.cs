using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Bloodbank.Ui
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            var services = Container.SetupServiceProvider();
            await services.GetRequiredService<BloodbankUi>().InitializeUi();
        }
    }
}
