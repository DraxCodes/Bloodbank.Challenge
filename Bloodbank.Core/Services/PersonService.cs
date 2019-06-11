using System;
using System.Collections.Generic;
using Bloodbank.Core.Models;

namespace Bloodbank.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IDataBase _db;
        public PersonService(IDataBase db)
        {
            _db = db;
        }

        public void RegisterPerson(Person person)
        {
            if (PersonExists(person)) { _db.Update(person); }
            _db.Store(person);
        }

        public void RegisterPeople(IEnumerable<Person> people)
        {
            foreach (var person in people)
                RegisterPerson(person);
        }



        private bool PersonExists(Person person) =>_db.Exists<Person>(x => x.Id == person.Id);
    }
}
