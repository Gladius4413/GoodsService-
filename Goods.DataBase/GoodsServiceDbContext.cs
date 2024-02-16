using Goods.DataBase.Configurations;
using Goods.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goods.DataBase
{
    public class GoodsServiceDbContext(DbContextOptions<GoodsServiceDbContext> options): DbContext(options)
    {
        public DbSet<GoodEntity> Goods { get; set; }

        public DbSet<UserEntity> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GoodConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
