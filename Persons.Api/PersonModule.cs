using Nancy;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Data;
using AutoMapper;
using Serilog;
using System.Text;
using Persons.Abstractions.Dto;
using System.Text.Json;
using Persons.Abstractions.Commands;
using Nancy.Extensions;

namespace Persons.Api
{
    public class PersonModule : NancyModule
    {
        private IRepository _repo;
        private IMapper _mapper;
        private ILogger _logger;

        public PersonModule(IRepository repo, IMapper mapper, ILogger logger) : base("/api/v1")
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;

            Get("/persons/{id}", parameters =>
            {
                var query = new FindPersonQuery(parameters.id);
                var handler = PersonQueryHandlerFactory.Build(query, _repo, _mapper, _logger);
                _logger.Information("Get request");
                var result = handler.Get();
                if (result == null)
                    return new NotFoundResponse();
                var res = Encoding.Default.GetBytes(JsonSerializer.Serialize(new PersonDetail
                {
                    BirthDate = result.BirthDate,
                    Name = result.Name
                }));
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(res, 0, res.Length)
                };

            });

            Post("/persons/", parameters =>
            {

                var body = this.Request.Body.AsString();
                var person = JsonSerializer.Deserialize<Person>(body);
                var command = new SavePersonCommand(person);  //new FindPersonQuery(parameters.id);
                            var handler = PersonCommandHandlerFactory.Build(command, _repo, _mapper, _logger);
                var result = handler.Execute();

                if (result != null) return new Response
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Created localhost:1234/persons/{result.ID.ToString()}"
                };
                return new Response
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    ReasonPhrase = "unprocessable entity"
                };
            });
        }
    }
}