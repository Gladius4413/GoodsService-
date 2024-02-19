using Goods.Core.Models;
using Goods.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.Services.Services
{
    public class UsersService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository) => _userRepository = userRepository;


        public async Task<List<User>> GetAllUsers()
        {
          return await _userRepository.GetAll();
        }

        public async Task<User?> GetUserByMail(string mail)
        {
            return await _userRepository.GetByEmail(mail);
        }

        public async Task Create(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task Update(Guid id, string name, string surname, string mail, string password)
        {
            await _userRepository.Update(id,name,surname,mail, password);
        }
        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

    }
}
