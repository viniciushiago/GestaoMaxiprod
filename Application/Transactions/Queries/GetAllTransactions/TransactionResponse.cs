using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Transactions.Queries.GetAllTransactions
{
    //DTO usado para retorno das informações
    public record TransactionResponse(
        long Id, 
        string Description,
        decimal Amount,
        string Type,
        string Category,
        long PersonId
    );
}
