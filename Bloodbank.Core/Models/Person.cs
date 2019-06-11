using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Bloodbank.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public BloodInfo BloodInfo { get; set; }
    }
}
