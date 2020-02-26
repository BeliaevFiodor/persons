using System;

namespace Persons.Abstractions.Data
{
    public interface IRepository
    {
        Person Find(Guid id);
        void Insert(Person item);
    }
}
