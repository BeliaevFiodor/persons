using System;
using System.Linq;


namespace Persons.Abstractions.Data
{
    public class Repository : IRepository
    {
        public Person Find(Guid id)
        {
            return MockPersonDatabase
                .Persons
                .First(p => p.Id == id);
        }

        public void Insert(Person item)
        {
            var person = MockPersonDatabase
                .Persons.FirstOrDefault(p => p.Id == item.Id);

            if (person == null)
            {
                MockPersonDatabase.Persons.Add(
                    new Person
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Age = item.Age
                    });
            }
        }
    }
}
