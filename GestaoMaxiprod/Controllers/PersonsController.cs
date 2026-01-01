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
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPersonsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeletePersonCommand(id));
            return NoContent();
        }

    }
}
