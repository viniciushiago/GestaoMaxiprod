using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest<Unit>
    {
        public long Id { get; set; }

        public DeletePersonCommand(long id)
        {
            Id = id;
        }
    }
}
