using Persons.Abstractions.Data;

namespace Persons.Abstractions.Commands
{
    public class SavePersonCommand : ICommand<CommandResponce>
    {
        public string Name { get; set; }
        public Person Person { get; protected set; }
        public SavePersonCommand(Person person)
        {
            Person = person;
        }
    }
}
