using GestaoMaxiprod.Application.Reports.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson
{
    public class GetTotalsByPersonHandler : IRequestHandler<GetTotalsByPersonQuery, TotalsByPersonResult>
    {
        // O handler depende apenas de uma interface,
        // mantendo baixo acoplamento com a infraestrutura
        private readonly IReportRepository _reportRepository;

        public GetTotalsByPersonHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<TotalsByPersonResult> Handle(GetTotalsByPersonQuery request, CancellationToken cancellationToken)
        {
            // Busca os dados através do repositório,
            // sem conhecimento de como os dados são persistidos
            return await _reportRepository.GetTotalsByPersonAsync();
        }
    }
}
