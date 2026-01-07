using GestaoMaxiprod.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionResponse>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsHandler(ITransactionRepository transactionRepository)
        { 
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TransactionResponse>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            //Busca as todas as transações de modo isolado
            var transactions = await _transactionRepository.GetAllAsync();

            //Retorno com as informações das transações
            return transactions.Select(x => new TransactionResponse(
                        x.Id,
                        x.Description,
                        x.Amount,
                        x.Type.ToString(),
                        x.Category.Description,
                        x.PersonId
                    )).ToList();
        }
    }
}
