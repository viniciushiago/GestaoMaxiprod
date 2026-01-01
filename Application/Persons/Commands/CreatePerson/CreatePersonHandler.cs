using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, long>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
        {
            var person = new Person(command.Name, command.Age);

            await _repository.AddAsync(person);

            return person.Id;
        }
    }
}
