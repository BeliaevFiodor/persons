using AutoMapper;
using Persons.Abstractions.Data;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Commands
{
    public class SavePersonCommandHandlerFactory : ICommandHandler<SavePersonCommand, CommandResponce>
    {
        private readonly SavePersonCommand _command;
        private ILogger _logger;
        public SavePersonCommandHandlerFactory(SavePersonCommand comm, IRepository repo, IMapper mapper, ILogger logger)
        {
            _command = comm;
            _logger = logger;
        }

        public CommandResponce Execute()
        {
            var responce = new CommandResponce
            {
                Success = false
            };

            try
            {
                var item = MockPersonDatabase
                    .Persons
                    .FirstOrDefault(p => p.Id == _command.Person.Id);

                if (item == null)
                {
                    item = new Person
                    {
                        Id = Guid.NewGuid(),
                        Name = _command.Person.Name,
                        Age = _command.Person.Age
                    };
                    MockPersonDatabase.Persons.Add(item);
                }
                else
                {
                    item.Name = _command.Person.Name;
                    item.Age = _command.Person.Age;
                }

                responce.ID = item.Id;
                responce.Success = true;
                responce.Message = "Person saved.";
                _logger.Information("Post request");
            }
            catch
            { }

            return responce;
        }
    }
}
