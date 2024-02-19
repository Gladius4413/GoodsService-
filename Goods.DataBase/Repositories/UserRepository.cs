using Goods.Core.Models;
using Goods.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.DataBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoodsServiceDbContext _dbContext;
        public UserRepository(GoodsServiceDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<User>> GetAll()
        {
            var userEntity = await _dbContext.User
                .AsNoTracking()
                .ToListAsync();

            var users = userEntity
                .Select(u => User.Create(u.Id, u.Name, u.Surname, u.Mail, u.Password).User)
                .ToList();

            return users;
        }

        public async Task<User?> GetByEmail(string mail)
        {
            var userEntity = await _dbContext.User
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Mail.Equals(mail));

            var user = User.Create(userEntity.Id, userEntity.Name, userEntity.Surname, userEntity.Mail, userEntity.Password).User;

            return user;
        }
        public async Task Create(User user)
        {
            var UserEntity = new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Mail = user.Mail,
                Password = user.Password
            };

            await _dbContext.User.AddAsync(UserEntity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Update(Guid id, string name, string surname, string mail, string password)
        {
            await _dbContext.User
                  .Where(u => u.Id == id)
                  .ExecuteUpdateAsync(s =>
                  s.SetProperty(u => u.Name, name)
                  .SetProperty(u => u.Surname, surname)
                  .SetProperty(u => u.Mail, mail)
                  .SetProperty(u => u.Password, password));
                  
        }
        public async Task Delete(Guid id)
        {
            await _dbContext.User
                  .Where(u => u.Id == id)
                  .ExecuteDeleteAsync();
        }

    }
}
