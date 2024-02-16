using Goods.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goods.DataBase
{
    public class GoodsServiceDbContext: DbContext
    {
        public DbSet<GoodEntity> Goods { get; set; }

        public DbSet<UserEntity> User { get; set; }
    }
}
