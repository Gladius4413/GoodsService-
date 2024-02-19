using Goods.Core.Models;
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
    public class GoodRepository : IGoodRepository
    {
        private readonly GoodsServiceDbContext _dbContext;
        public GoodRepository(GoodsServiceDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<Good>> GetAll()
        {
            var goodEntities =  await _dbContext.Goods
                .AsNoTracking()
                .ToListAsync();

            var goods = goodEntities.Select(g => Good.Create(g.Id, g.Title, g.Price, g.Description))
                .ToList();

            return goods;
        }

        public async Task<Good?> GetById(Guid id)
        {
            var goodEntity = await _dbContext.Goods
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);

            var good = Good.Create(goodEntity.Id, goodEntity.Title, goodEntity.Price, goodEntity.Description);
            return good;
        }

        public async Task Create(Good good)
        {
            var goodEntity = new GoodEntity
            {
                Id = good.Id,
                Title = good.Title,
                Price = good.Price,
                Description = good.Description
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
