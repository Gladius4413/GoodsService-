using Goods.Core.Abstractions;
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

        public async Task<List<Users>> GetAll()
        {
            var userEntity = await _dbContext.User
                .AsNoTracking()
                .ToListAsync();

            var users = userEntity
                .Select(u => Users.Create(u.Id, u.Name, u.Surname, u.Mail, u.Password).User)
                .ToList();

            return users;
        }

        public async Task<Users?> GetByEmail(string mail)
        {
            var userEntity = await _dbContext.User
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Mail.Equals(mail));

            if (userEntity == null)
            {
                return null;
            }

            var user = Users.Create(userEntity.Id, userEntity.Name, userEntity.Surname, userEntity.Mail, userEntity.Password).User;

            return user;
        }
        public async Task<Guid> Create(Users user)
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

            return user.Id;
        }


        public async Task<Guid> Update(Guid id, string name, string surname, string mail, string password)
        {
           await _dbContext.User
                  .Where(u => u.Id == id)
                  .ExecuteUpdateAsync(s =>
                  s.SetProperty(u => u.Name, name)
                  .SetProperty(u => u.Surname, surname)
                  .SetProperty(u => u.Mail, mail)
                  .SetProperty(u => u.Password, password));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.User
                  .Where(u => u.Id == id)
                  .ExecuteDeleteAsync();

            return id;
        }

    }
}
