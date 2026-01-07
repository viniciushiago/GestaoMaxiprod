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
        // O handler depende apenas de uma abstração (interface),
        // mantendo baixo acoplamento com a infraestrutura
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<PersonResponse>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            // Busca os dados através do repositório,
            // sem conhecimento de como os dados são persistidos
            var persons = await _personRepository.GetAllAsync();

            // Usa DTOs de resposta para mapear objeto,
            // evitando mostrar o domínio diretamente para a API
            return persons.Select(x => new PersonResponse(
                x.Id,
                x.Name,
                x.Age        
            )).ToList();
        }
    }
}
