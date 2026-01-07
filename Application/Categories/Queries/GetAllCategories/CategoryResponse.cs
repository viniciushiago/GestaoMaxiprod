using GestaoMaxiprod.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Categories.Queries.GetAllCategories
{
    //DTO de response com as informações das categorias
    public record CategoryResponse(long id, string description, CategoryPurpose CategoryPurpose);
}
