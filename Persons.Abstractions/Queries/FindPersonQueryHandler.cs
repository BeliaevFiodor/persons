using Persons.Abstractions.Data;
using AutoMapper;
using Persons.Abstractions.Dto;
using Serilog;

namespace Persons.Abstractions.Queries
{
    public class FindPersonQueryHandler : IQueryHandler<FindPersonQuery, PersonDetail>
    {
        private FindPersonQuery _query;
        private IRepository _repo;
        private IMapper _mapper;
        private ILogger _logger;
        public FindPersonQueryHandler(FindPersonQuery query, 
            IRepository repo,
            IMapper mapper,
            ILogger logger)
        {
            _query = query;
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }
        public PersonDetail Get()
        {
            var person = _repo.Find(_query.Id);
            var personDto =  _mapper.Map<Person, PersonDetail>(person);
            _logger.Information("Get request");
            return personDto; 
        }
    }
}
