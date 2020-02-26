using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Commands
{
    public class CommandResponce
    {
        public Guid ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
