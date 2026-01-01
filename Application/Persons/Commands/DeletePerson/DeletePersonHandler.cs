using Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, Unit>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.Id);

            if( person is null)
            {
                throw new ArgumentException("Pessoa não encontrada.");
            }

            await _personRepository.RemoveAsync(person);

            return Unit.Value;
        }
    }
}
