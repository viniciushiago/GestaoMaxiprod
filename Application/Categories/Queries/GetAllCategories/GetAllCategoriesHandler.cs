using GestaoMaxiprod.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategorieQuery, List<CategoryResponse>>
    {
        //Depende apenas de uma interface, para baixo acomplamento
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryResponse>> Handle(GetAllCategorieQuery query, CancellationToken cancellationToken)
        {
            // Faz a busca de todas as categorias
            var categories = await _categoryRepository.GetAllAsync();

            //utiliza o dto para retornar as informações
            return categories
                .Select(x => new CategoryResponse(x.Id, x.Description, x.CategoryPurpose))
                .ToList();
        }
    }
}
