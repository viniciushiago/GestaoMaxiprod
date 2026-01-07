using GestaoMaxiprod.Domain.Entities;
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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GestaoDbContext _context;

        public CategoryRepository(GestaoDbContext context)
        {
            _context = context;
        }

        public async Task AddASync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }
    }
}
