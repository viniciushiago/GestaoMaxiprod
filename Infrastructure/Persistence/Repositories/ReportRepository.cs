using GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson;
using GestaoMaxiprod.Application.Reports.Repositories;
using GestaoMaxiprod.Domain.Enums;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Infrastructure.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly GestaoDbContext _context;

        public ReportRepository(GestaoDbContext context)
        {
            _context = context;
        }

        public async Task<TotalsByPersonResult> GetTotalsByPersonAsync()
        {
            var persons = await _context.Persons
                .AsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    TotalsIncome = x.Transaction
                    .Where(t => t.Type == TransactionType.Income)
                    .Sum(t => (decimal?)t.Amount) ?? 0,

                    TotalsExpense = x.Transaction
                    .Where(t => t.Type == TransactionType.Expense)
                    .Sum(t => (decimal?)t.Amount) ?? 0
                }).ToListAsync();

            var personsTotals = persons
                .Select(x => new PersonTotalsResponse(
                        x.Id,
                        x.Name,
                        x.TotalsExpense,
                        x.TotalsIncome,
                        x.TotalsIncome - x.TotalsExpense
                    )).ToList();

            var totalsIncome = personsTotals.Sum(x => x.TotalIncome);
            var totalsExpense = personsTotals.Sum(x => x.TotalExpense);

            var overall = new OverallTotalsResponse(
                    totalsIncome,
                    totalsExpense,
                    totalsIncome - totalsExpense
                );

            return new TotalsByPersonResult(personsTotals, overall);

        }
    }
}
