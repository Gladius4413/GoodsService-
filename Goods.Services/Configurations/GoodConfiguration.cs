using Goods.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.DataBase.Configurations
{
    public class GoodConfiguration : IEntityTypeConfiguration<GoodEntity>
    {
        public void Configure(EntityTypeBuilder<GoodEntity> builder)
        {
            builder.HasKey(g => g.Id);
            builder
                .HasMany(u => u.Users)
                .WithMany(g => g.Goods);
        }
    }
}
