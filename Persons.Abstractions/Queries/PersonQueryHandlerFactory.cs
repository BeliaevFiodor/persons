using AutoMapper;
using Persons.Abstractions.Data;
using Persons.Abstractions.Dto;
using Serilog;

namespace Persons.Abstractions.Queries
{
    public static class PersonQueryHandlerFactory
    {
        public static IQueryHandler<FindPersonQuery, PersonDetail> Build(FindPersonQuery query, IRepository repo, IMapper mapper, ILogger logger)
        {
            return new FindPersonQueryHandler(query, repo, mapper, logger);
        }
    }
}
