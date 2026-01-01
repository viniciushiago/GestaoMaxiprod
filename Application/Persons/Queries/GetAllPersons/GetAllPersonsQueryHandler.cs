using Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<PersonResponse>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<PersonResponse>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAllAsync();

            return persons.Select(x => new PersonResponse
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
            }).ToList();
        }
    }
}
