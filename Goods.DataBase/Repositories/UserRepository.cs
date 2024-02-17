using Goods.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.DataBase.Repositories
{
    public class UserRepository
    {
        private readonly GoodsServiceDbContext _dbContext;
        public UserRepository(GoodsServiceDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<UserEntity>> GetAll()
        {
            return await _dbContext.User
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task Create(Guid id, string name, string surname, string mail, string password)
        {
           var User = new UserEntity()
           {
               Id = id,
               Name = name,
               Surname = surname,
               Mail = mail,
               Password = password
           };

            await _dbContext.User.AddAsync(User);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserEntity?> GetByEmail(string mail)
        {
            return await _dbContext.User
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Mail.Equals(mail))
                ?? throw new Exception("User doesn't exist");
        }
        public async Task Update(Guid id,string name, string surname, string password, string mail)
        {
            await _dbContext.User
                  .Where(u => u.Id == id)
                  .ExecuteUpdateAsync(s =>
                  s.SetProperty(u => u.Name, name)
                  .SetProperty(u => u.Surname, surname)
                  .SetProperty(u => u.Password, password)
                  .SetProperty(u => u.Mail, mail));
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.User
                  .Where(u => u.Id == id)
                  .ExecuteDeleteAsync();
        }

    }
}
