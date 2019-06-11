using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Bloodbank.Core.Models;

namespace Bloodbank.Core.Providers
{
    public interface IPersonProvider
    {
        Person GetPerson(int id);
        IEnumerable<Person> GetPeople<T>(Expression<Func<Person, bool>> predicate);
    }
}
