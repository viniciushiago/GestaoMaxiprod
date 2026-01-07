using Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            //Depende apenas de uma interface
            _personRepository = personRepository;
        }

        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            //Busca a pessoa
            var person = await _personRepository.GetByIdAsync(request.id);

            //Verifica se a pessoa existe
            if( person is null)
            {
                throw new ArgumentException("Pessoa não encontrada.");
            }

            //Faz a deleção da pessoa de forma isolada em sua camada
            await _personRepository.RemoveAsync(person);
        }
    }
}
