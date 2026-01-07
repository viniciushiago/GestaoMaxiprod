using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Domain.Interfaces.Repositories
{
    //Portas que deixam o código com baixo acomplamento em outras camadas
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<List<Transaction>> GetAllAsync();
    }
}
