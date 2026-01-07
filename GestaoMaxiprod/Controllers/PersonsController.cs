using GestaoMaxiprod.Application.Persons.Commands.CreatePerson;
using GestaoMaxiprod.Application.Persons.Commands.DeletePerson;
using GestaoMaxiprod.Application.Persons.Queries.GetAllPersons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoMaxiprod.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            // O controller não conhece handlers nem repositórios,
            // apenas envia comandos e consultas via Mediatr
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Envia o comando para a camada de aplicação
            var result = await _mediator.Send(new GetAllPersonsQuery());
            // Retorna HTTP 200 com as informações obtidas
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            // Envia o comando para a camada de aplicação
            var id = await _mediator.Send(command);
            // Retorna HTTP 201 com o identificador criado
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Envia o comando para a camada de aplicação
            await _mediator.Send(new DeletePersonCommand(id));
            // Não retorna nenhum conteúdo
            return NoContent();
        }

    }
}
