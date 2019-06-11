using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bloodbank.Core.Models;

namespace Bloodbank.Core.Providers
{
    public interface IPersonProvider
    {
        Person GetPersonById(int id);
        Person GetPerson(Expression<Func<Person, bool>> predicate);
        IEnumerable<Person> GetPeople<T>(Expression<Func<Person, bool>> predicate);
    }
}
