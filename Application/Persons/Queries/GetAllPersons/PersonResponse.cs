using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Queries.GetAllPersons
{
    public class PersonResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
