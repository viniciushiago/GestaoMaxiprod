using Domain.Entities;
using GestaoMaxiprod.Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly GestaoDbContext _context;
        public TransactionRepository(GestaoDbContext context)
        {
            // DbContext fica restrito a camada de infraestrutura
            _context = context;
        }
        public async Task AddAsync(Transaction transaction)
        {
            // O repositório é responsável apenas por persistência,
            // sem conter regras de negócio
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            // O repositório é responsável apenas por obter,
            // sem conter regras de negócio
            return await _context.Transactions
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
