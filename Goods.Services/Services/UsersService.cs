using Goods.Core.Abstractions;
using Goods.Core.Models;
using Goods.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository) => _userRepository = userRepository;


        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<Users?> GetUserByMail(string mail)
        {
            return await _userRepository.GetByEmail(mail);
        }

        public async Task<Guid> Create(Users user)
        {
            var checkUser = _userRepository.GetByEmail(user.Mail);
            if (checkUser == null)
            {
                return Guid.Empty;
            }
            await _userRepository.Create(user);
            return user.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string surname, string mail, string password)
        {
            return await _userRepository.Update(id, name, surname, mail, password);
            
        }
        public async Task<Guid> Delete(Guid id)
        {
          return  await _userRepository.Delete(id);
        }

    }
}
