using GestaoMaxiprod.Application.Categories.Commands.CreateCategoryCommand;
using GestaoMaxiprod.Application.Categories.Queries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoMaxiprod.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            // O controller não conhece handlers nem repositórios,
            // apenas envia comandos e consultas via MediatR
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            // Envia o comando para a camada de aplicação
            var id = await _mediator.Send(command);
            // Retorna HTTP 201 com o identificador criado
            return CreatedAtAction(nameof(GetAll), new  { id }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Envia o comando para a camada de aplicação
            var result = await _mediator.Send(new GetAllCategorieQuery());
            // Retorna HTTP 200 com as informações obtidas
            return Ok(result);
        }
    }
}
