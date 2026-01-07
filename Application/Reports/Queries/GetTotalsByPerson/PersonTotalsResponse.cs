using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson
{
    //DTO de retorno das informações de Receita/Despesas por pessoa
    public record PersonTotalsResponse(
            long PersonId,
            string PersonName,
            decimal TotalExpense,
            decimal TotalIncome,
            decimal Balance
        );
}
