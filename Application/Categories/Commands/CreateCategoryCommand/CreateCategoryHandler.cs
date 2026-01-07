using GestaoMaxiprod.Domain.Entities;
using GestaoMaxiprod.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, long>
    {
        //Depende apenas de uma interface, deixando com baixo acoplamento
        private readonly ICategoryRepository _repository;

        public CreateCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Description, request.CategoryPurpose);

            //Faz a inserção da categoria, em sua camada de forma isolada
            await _repository.AddASync(category);

            //Retorna apenas o ID da categoria criada
            return category.Id;
        }
    }
}
