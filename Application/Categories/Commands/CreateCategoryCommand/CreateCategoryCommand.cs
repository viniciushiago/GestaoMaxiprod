using GestaoMaxiprod.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Application.Categories.Commands.CreateCategoryCommand
{
    //DTO de request para criação das categorias
    public class CreateCategoryCommand : IRequest<long>
    {

        public string Description { get; init; } = string.Empty;
        public CategoryPurpose CategoryPurpose{ get; init; }
    }
}
