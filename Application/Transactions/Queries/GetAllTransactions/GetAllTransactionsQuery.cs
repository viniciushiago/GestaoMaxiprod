using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQuery : IRequest<List<TransactionResponse>>
    {
    }
}
