using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<long>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
