using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson
{
    //DTO com retorno total das Depesas/Receitas de todas as pessoas
    public record OverallTotalsResponse(
            decimal TotalIncome,
            decimal TotalExpense,
            decimal Balance
        );
}
