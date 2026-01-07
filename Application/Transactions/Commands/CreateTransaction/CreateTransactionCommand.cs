using GestaoMaxiprod.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Transactions.Commands.CreateTransaction
{
    //DTO para criação das transações
    public record CreateTransactionCommand(
        string Description,
        decimal Amount,
        TransactionType Type,
        long CategoryId,
        long PersonId
    ) : IRequest<long>;
}
