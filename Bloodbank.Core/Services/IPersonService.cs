using System.Collections.Generic;
using Bloodbank.Core.Models;

namespace Bloodbank.Core.Services
{
    public interface IPersonService
    {
        void RegisterPerson(Person person);
        void RegisterPeople(IEnumerable<Person> people);
    }
}
