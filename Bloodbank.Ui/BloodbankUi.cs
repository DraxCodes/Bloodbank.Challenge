using System.Threading;
using System.Threading.Tasks;
using Bloodbank.Core.Providers;
using Bloodbank.Core.Services;
using Bloodbank.Core.SystemAbstractions;

namespace Bloodbank.Ui
{
    public class BloodbankUi
    {
        private readonly ILogger _logger;
        private readonly IConsole _console;
        private readonly IPersonService _personService;
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public BloodbankUi(ILogger logger, IConsole console, IPersonService personService)
        {
            _logger = logger;
            _console = console;
            _personService = personService;
        }
        public Task InitializeUi()
        {
            //Todo: Remove this shite maybe
            _logger.Write("Welcome to the Bloodbank.\n");
            while (!cancellationToken.Token.IsCancellationRequested)
            {
                _logger.Write("Please select which option you require.\n" +
                              "1: Register\n" +
                              "2: Lookup person\n" +
                              "3: Count Entries\n" +
                              "4: Close\n");
                var selection = _console.ReadLine();

                //Todo: check for issues.
                var selectedInt = int.Parse(selection);
                SwitchSelection(selectedInt);
            }

            return Task.CompletedTask;;
        }

        public void SwitchSelection(int selection)
        {
            switch (selection)
            {
                case 1:
                    _personService.RegisterPerson();
                    break;
                case 2:
                    _personService.DisplayPersonInformation();
                    break;
                case 3:
                    _personService.DisplayEntries();
                    break;
                case 4:
                    cancellationToken.Cancel();
                    break;
                default:
                    _logger.Log("Incorrect Selection");
                    break;;
            }
        }

        
    }
}
