using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly GestaoDbContext _dbContext;

        public PersonRepository(GestaoDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task AddAsync(Person person)
        {
            await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _dbContext.Persons
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(long id)
        {
            return await _dbContext.Persons
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveAsync(Person person)
        {
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}
