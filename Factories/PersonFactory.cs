using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private int Id = 0;

        public Person CreatePerson(string Name)
        {
            var person = new Person
            {
                Name = Name,
                Id = Id
            };
            Id += 1;
            return person;
        }
    }
}
