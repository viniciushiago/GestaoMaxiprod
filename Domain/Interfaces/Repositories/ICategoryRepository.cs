using GestaoMaxiprod.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Domain.Interfaces.Repositories
{
    //Portas que deixam o código com baixo acomplamento em outras camadas
    public interface ICategoryRepository
    {
        Task AddASync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(long id);
    }
}
