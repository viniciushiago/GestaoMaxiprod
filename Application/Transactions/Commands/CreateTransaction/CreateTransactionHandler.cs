using Domain.Entities;
using Domain.Interfaces.Repositories;
using GestaoMaxiprod.Domain.Enums;
using GestaoMaxiprod.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, long>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionHandler(
           IPersonRepository personRepository,
           ICategoryRepository categoryRepository,
           ITransactionRepository transactionRepository)
        {
            _personRepository = personRepository;
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<long> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            // Recupera a pessoa para validações de negócio
            var person = await _personRepository.GetByIdAsync(request.PersonId)
                ?? throw new Exception("Pessoa não encontrada.");

            // Recupera a categoria para validar compatibilidade com o tipo da transação
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId)
                ?? throw new Exception("Categoria não encontrada.");

            // Criação da entidade repassado ao domínio,
            // garantindo que TODAS as regras fiquem centralizadas
            var transaction = new Transaction(
                request.Description,
                request.Amount,
                request.Type,
                person,
                category);

            // Persistência isolada no repositório
            await _transactionRepository.AddAsync(transaction);


            // Retorna apenas o identificador, mantendo o comando simples
            return transaction.Id;
        }
    }
}
