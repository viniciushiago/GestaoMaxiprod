using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson
{
    //DTO de retorno totais, de pessoas e geral.
    public record TotalsByPersonResult(
            IReadOnlyList<PersonTotalsResponse> Persons,
            OverallTotalsResponse OverallTotal
        );
}
