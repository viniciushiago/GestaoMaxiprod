using GestaoMaxiprod.Application.Categories.Queries.GetAllCategories;
using GestaoMaxiprod.Application.Transactions.Commands.CreateTransaction;
using GestaoMaxiprod.Application.Transactions.Queries.GetAllTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoMaxiprod.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            // O controller não conhece handlers nem repositórios,
            // apenas envia comandos e consultas via Mediatr
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Envia o comando para a camada de aplicação
            var result = await _mediator.Send(new GetAllTransactionsQuery());
            // Retorna HTTP 200 com as informações obtidas
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateTransactionCommand command,
            CancellationToken cancellationToken)
        {
            // Envia o comando para a camada de aplicação
            var transactionId = await _mediator.Send(command, cancellationToken);
            // Retorna HTTP 201 com o identificador criado
            return CreatedAtAction(nameof(Create), new { id = transactionId }, null);
        }
    }
}
