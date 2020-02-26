using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Queries
{
    public interface IQuery<TResponse> { }

    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get();
    }

}
