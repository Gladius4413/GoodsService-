using Goods.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.DataBase.Repositories
{
    public class GoodRepository
    {
        private readonly GoodsServiceDbContext _dbContext;
        public GoodRepository(GoodsServiceDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<GoodEntity>> GetAll()
        {
            return await _dbContext.Goods
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GoodEntity?>GetById(Guid id)
        {
            return await _dbContext.Goods
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(string title, decimal price, string description)
        {
           var goodEntity = new GoodEntity 
           {
               Title = title,
               Price = price, 
               Description = description
           };

            await _dbContext.Goods.AddAsync(goodEntity);
            await _dbContext.SaveChangesAsync();   
        }

        public async Task Update(Guid id, string title, decimal price, string description)
        {
             await _dbContext.Goods
                .Where(g => g.Id == id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(g => g.Title, title)
                .SetProperty(g => g.Price, price)
                .SetProperty(g => g.Description, description));
                
                
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.Goods
                .Where(g => g.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
