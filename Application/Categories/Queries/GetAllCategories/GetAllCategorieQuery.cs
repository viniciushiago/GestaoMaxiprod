using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Categories.Queries.GetAllCategories
{ 
    public class GetAllCategorieQuery : IRequest<List<CategoryResponse>>
    {
    }
}
