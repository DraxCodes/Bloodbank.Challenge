using System;
using System.Collections.Generic;
using Bloodbank.Core.Models;
using Bloodbank.Core.Providers;
using Bloodbank.Core.SystemAbstractions;
using Console = System.Console;

namespace Bloodbank.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IDataBase _db;
        private readonly IConsole _console;
        private readonly ILogger _logger;
        private readonly IPersonProvider _personProvider;

        public PersonService(IDataBase db, IConsole console, ILogger logger, IPersonProvider personProvider)
        {
            _db = db;
            _console = console;
            _logger = logger;
            _personProvider = personProvider;
        }

        //TODO: Refactor.

        public void RegisterPerson(Person person = null)
        {
            if (person is null)
                person = new Person();

            _logger.Write("Please Enter your first name.");
            person.FirstName = _console.ReadLine();

            _logger.Write("Please Enter your last name.");
            person.LastName = _console.ReadLine();

            _logger.Write("Please enter your address.");
            person.Address = _console.ReadLine();

            person.BloodInfo = new BloodInfo
            {
                BloodType = GetBloodType()
            };

            _logger.Write("Thankyou, you are now registered.");

            if (PersonExists(person)) { _db.Update(person); }
            _db.Store(person);
        }

        public void RegisterPeople(IEnumerable<Person> people)
        {
            foreach (var person in people)
                RegisterPerson(person);
        }

        public void DisplayPersonInformation()
        {
            //TODO: Move try/catch
            try
            {
                _logger.Write("Enter first name.");
                var firstName = _console.ReadLine().ToLower();

                _logger.Write("Enter last name.");
                var lastName = _console.ReadLine().ToLower();

                //Todo: ignore case better.

                var person = _personProvider.GetPerson(x =>
                    x.FirstName.ToLower() == firstName &&
                    x.LastName.ToLower() == lastName);

                _logger.Write($"\nName: {person.FirstName} {person.LastName}\n" +
                                   $"Blood-type: {person.BloodInfo.BloodType}\n" +
                                   $"Is Universal Blood Donor: {person.BloodInfo.IsUniversalRedCellDonor}\n" +
                                   $"Is Universal Plasma Donor: {person.BloodInfo.IsUniversalPlasmaDonor}\n");
            }
            catch (Exception)
            {
               _logger.Log("Sorry, Person note found.");
            }
        }

        public void DisplayEntries()
        {
            var entries = _db.Count<Person>();
            _logger.Write($"Current Entries: {entries}\n");
        }

        private BloodType GetBloodType()
        {
            _logger.Write("Please select your Bloodtype (num)");
            var num = 0;
            foreach (var item in Enum.GetValues(typeof(BloodType)))
            {
                _logger.Log($"{num}: {item.ToString()}");
                num++;
            }
            //TODO: Check for incorrect entries.
            var selection = _console.ReadLine();
            var id = int.Parse(selection);

            return (BloodType) id;
        }

        private bool PersonExists(Person person) =>_db.Exists<Person>(x => x.Id == person.Id);
    }
}
