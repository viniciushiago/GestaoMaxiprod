using GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Reports.Repositories
{
    public interface IReportRepository
    {
        Task<TotalsByPersonResult> GetTotalsByPersonAsync();
    }
}
