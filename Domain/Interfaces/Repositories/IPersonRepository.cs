using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    //Portas que deixam o código com baixo acomplamento em outras camadas
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task<Person?> GetByIdAsync(long id);
        Task<List<Person>> GetAllAsync();
        Task RemoveAsync(Person person);
    }
}
