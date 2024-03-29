﻿using System;
using Bloodbank.Core;
using Bloodbank.Core.Providers;
using Bloodbank.Core.Services;
using Bloodbank.DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace Bloodbank.Ui
{
    public static class Container
    {
        public static IServiceProvider SetupServiceProvider()
            => new ServiceCollection()
                .AddTransient<IDataBase, LDataBase>()
                .AddSingleton<BloodbankUi>()
                .UseBloodbankCore()
                .BuildServiceProvider();
    }
}
