using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<List<PersonResponse>>
    {   
    }
}
