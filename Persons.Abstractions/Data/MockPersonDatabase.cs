using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Data
{
    public static class MockPersonDatabase
    {
        public static IList<Person> Persons { get; }

        static MockPersonDatabase()
        {
            Persons = new List<Person>()
            {
                new Person() { Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"), Name = "Васька", Age = 37 },
                new Person() { Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857710"), Name = "Сашка", Age = 28 },
                new Person() { Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857711"), Name = "Петька", Age = 27 }
            };
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        private int _age;
        public int? Age
        {
            get {
                if(_age > 120 || Name == null)
                    return null;
                return _age;
            }
            set { _age = GetAge(); }
        }

        private int GetAge()
        {
            int curYear = DateTime.Now.Year;
            int curMonth = DateTime.Now.Month;
            int curDay = DateTime.Now.Day;

            int age = curYear - BirthDay.Year;
            if (curMonth < BirthDay.Month && curDay < BirthDay.Day)
                return age - 1;
            return age;
        }
    }
}
