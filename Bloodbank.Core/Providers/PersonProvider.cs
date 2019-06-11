using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bloodbank.Core.Models;
using Bloodbank.Core.Services;

namespace Bloodbank.Core.Providers
{
    public class PersonProvider : IPersonProvider
    {
        private readonly IDataBase _db;
        public PersonProvider(IDataBase db)
        {
            _db = db;
        }


        public Person GetPerson(int id)
            => _db.RestoreSingle<Person>(x => x.Id == id);

        public IEnumerable<Person> GetPeople<T>(Expression<Func<Person, bool>> predicate)
            => _db.RestoreMany(predicate);

        //Maybe Add store.... 
        //NEED TO DISCORDTHINK
        //LETS WORK REVERSE
    }
}
