using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Commands.DeletePerson
{
    //DTO para deleção de uma pessoa
    public record DeletePersonCommand(long id) : IRequest;
}
