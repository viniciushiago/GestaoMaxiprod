using GestaoMaxiprod.Application.Reports.Queries.GetTotalsByPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoMaxiprod.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            // O controller não conhece handlers nem repositórios,
            // apenas envia comandos e consultas via MediatR
            _mediator = mediator;
        }

        [HttpGet("totals-by-person")]
        public async Task<ActionResult<TotalsByPersonResult>> GetTotalsByPerson()
        {
            // Envia o comando para a camada de aplicação
            var result = await _mediator.Send(new GetTotalsByPersonQuery());
            // Retorna HTTP 200 com as informações obtidas
            return Ok(result);
        }
    }
}
