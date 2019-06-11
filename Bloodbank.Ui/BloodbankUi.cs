using System.Threading.Tasks;
using Bloodbank.Core.Providers;
using Bloodbank.Core.Services;

namespace Bloodbank.Ui
{
    public class BloodbankUi
    {
        private readonly ILogger _logger;
        private readonly IPersonService _personService;
        private readonly IPersonProvider _personProvider;

        public BloodbankUi(ILogger logger, IPersonService personService, IPersonProvider personProvider)
        {
            _logger = logger;
            _personService = personService;
            _personProvider = personProvider;
        }
        public async Task InitializeUi()
        {
            _logger.Log("Working I guess.");
            _personService.RegisterPerson();

            await Task.Delay(-1);
        }

        
    }
}
