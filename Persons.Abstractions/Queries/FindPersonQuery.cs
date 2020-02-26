using Persons.Abstractions.Data;
using Persons.Abstractions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Queries
{
    public class FindPersonQuery : IQuery<PersonDetail>
    {
        public Guid Id { get; private set; }
        public FindPersonQuery(Guid id)
        {
            Id = id;
        }
    }
}
