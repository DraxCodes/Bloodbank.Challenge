using System;
using System.Threading.Tasks;
using Bloodbank.Core.Models;
using Bloodbank.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bloodbank.Ui
{
    public class BloodbankUi
    {
        private readonly ILogger _logger;

        public BloodbankUi(IServiceProvider services)
        {
            _logger = services.GetRequiredService<ILogger>();
        }
        public async Task InitializeUi()
        {
            _logger.Log("Working I guess.");


            await Task.Delay(-1);
        }

        private Person GeneratePerson()
        {
            var address = new Address
            {
                City = "Sheffield",
                Country = "Uk",
                HouseNum = 234,
                PostCode = "S4 8NT",
                RoadName = "Something"
            };

            var person = new Person
            {
                Id = 1,
                Address = address,
                BloodInfo = new BloodInfo
                {
                    BloodType = BloodType.ABNegative
                },
                FirstName = "Drax",
                LastName = "Codes"
            };

            return person;
        }
    }
}
